﻿
using AuthenticationMechanism.Services;
using AuthenticationMechanism.tokenservice;
using AutoMapper;
using Azure;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EduNexBL.DTOs.AuthDtos;
using EduNexBL.DTOs.ExamintionDtos;
using EduNexBL.IRepository;
using EduNexDB.Context;
using EduNexDB.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduNexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly EduNexContext _context;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;
        public TeacherController(CloudinaryService cloudinaryService, TokenService tokenService, UserManager<IdentityUser> userManager,IMapper mapper, SignInManager<IdentityUser> signInManager, EduNexContext context)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("register/teacher")]
        public async Task<ActionResult<RegisterTeacherDto>> TeacherRegister(RegisterTeacherDto model, IFormFile file)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email is already taken
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError("Email", "Email is already taken.");
                return BadRequest(ModelState);
            }
            
            // Upload profile photo to Cloudinary

            var uploadResult = await _cloudinaryService.UploadAsync(file);

            // Create a new user with Identity Framework
            var newUser = _mapper.Map<Teacher>(model);
            //var newUser = new Teacher
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    PhoneNumber = model.PhoneNumber,
            //    gender = (Gender)Enum.Parse(typeof(Gender), model.gender),
               
            //    DateOfBirth = model.DateOfBirth,
            //    Address = model.Address,
            //    NationalId = model.NationalId,
            //    Email = model.Email,
            //    UserName = model.Email,
              
            //    FacebookAccount = model.FacebookAccount,
            //    CityId= model.CityId
            //};


            // Set profile photo URL from Cloudinary upload result

            newUser.ProfilePhoto = uploadResult.SecureUri.ToString();


            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Teacher");

               

                var token = _tokenService.GenerateAccessToken(newUser.Id);

                // Return the created user and the token as a response
                return Ok(  token);
            }

            // If the user creation failed, return a bad request response with the errors
            return BadRequest(result.Errors);
        }
        //private async Task<ImageUploadResult> UploadPhotoToCloudinary(IFormFile file)
        //{
        //    using (var stream = file.OpenReadStream())
        //    {
        //        var uploadParams = new ImageUploadParams
        //        {
        //            File = new FileDescription(file.FileName, stream),
        //            Transformation = new Transformation().Width(150).Height(150).Crop("thumb")
        //        };

        //        var uploadResult = await _cloudinaryService.UploadAsync(uploadParams);

        //        return uploadResult;
        //    }
        //}
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginUserDto>> TeacherLogin(LoginUserDto model)

        {

            // Validate the model

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }


            // Check if the email and password are valid

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);


            if (!result.Succeeded)

            {

                ModelState.AddModelError("", "Invalid email or password.");

                return BadRequest(ModelState);

            }


            // Get the user

            var user = await _userManager.FindByEmailAsync(model.Email);


            if (user == null)

            {

                ModelState.AddModelError("", "Invalid email or password.");

                return BadRequest(ModelState);

            }


            // Check if the user is a teacher

            if (!await _userManager.IsInRoleAsync(user, "Teacher"))

            {

                ModelState.AddModelError("", "Invalid email or password.");

                return BadRequest(ModelState);

            }



            var token = _tokenService.GenerateAccessToken(user.Id);



            return Ok( token);

        }
    }
}
