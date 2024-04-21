//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using EduNexBL.IRepository;
//using EduNexBL.Iservice;
//using EduNexDB.Entites.identity;
//using Microsoft.AspNetCore.Identity;

//namespace EduNexBL.service
//{
//    public class AccountService : IAccountService
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly ITokenService _tokenService;
//        private readonly IMapper _mapper;
//        private readonly IAccountRepository _accountRepo;

//        public AccountService(IMapper mapper, IAccountRepository accountRepo, ITokenService tokenService, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
//        {
//            _mapper = mapper;
//            _accountRepo = accountRepo;
//            _tokenService = tokenService;
//            _signInManager = signInManager;
//        }

//        public async Task<ApplicationUser?> AddUser(UserDTO user, string roleName, int? specializationId)
//        {
//            ApplicationUser? newUser = null;

//            if (roleName == "Doctor")
//            {
//                newUser = CreateDoctorUser(user, specializationId);
//            }
//            else
//            {
//                newUser = _mapper.Map<CoreAPI.DTOs.UserDTO, Patient>(user);
//            }

//            return await CreateUserAndRole(newUser, user.Password, roleName);
//        }


//        private Doctor CreateDoctorUser(CoreAPI.DTOs.UserDTO user, int? specializationId)
//        {
//            var doctor = _mapper.Map<CoreAPI.DTOs.UserDTO, Doctor>(user);
//            doctor.SpecializationId = specializationId ?? default(int);
//            return doctor;
//        }

//        private async Task<ApplicationUser?> CreateUserAndRole(ApplicationUser user, string password, string roleName)
//        {
//            var result = await _accountRepo.CreateUser(user, password);

//            if (result)
//            {
//                await _accountRepo.AddRole(user, roleName);
//                return user;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public async Task<bool> DeleteDoctor(string id)
//        {
//            var doctor = await _doctorRepository.GetDoctorWithBookings(id);

//            if (doctor == null || doctor.requests.Any(r => r.BookingState == BookingStatus.Pending))
//            {
//                return false;
//            }

//            _accountRepo.DeleteDoctor(doctor);
//            await _accountRepo.SaveChanges();
//            return true;
//        }

//        public async Task<int> GetCount()
//        {
//            return await _unitOfWork.Repository<Booking>().GetCount();
//        }

//        public async Task<ApplicationUser?> GetUserInRoleById(string roleName, string id)
//        {
//            var user = await _accountRepo.GetUserById(id);
//            var isInRole = await _accountRepo.IsUserInRole(roleName, user);

//            return isInRole ? user : null;
//        }

//        public async Task<IList<ApplicationUser>> GetUsersInRole(string roleName)
//        {
//            return await _accountRepo.GetUsersInRole(roleName);
//        }

//        public async Task<ApplicationUser?> Login(CoreCore.DTOs.LoginDto model)
//        {
//            var user = await _accountRepo.GetUserByEmail(model.Email);

//            return user != null && (await _signInManager.CheckPasswordSignInAsync(user, model.Password, false)).Succeeded ? user : null;
//        }

//        public async Task<bool> UpdateUser(CoreAPI.DTOs.UserDTO userUpdated, int specialization)
//        {
//            var user = await _accountRepo.GetDoctorByEmail(userUpdated.Email);
//            _mapper.Map(userUpdated, user);
//            user.SpecializationId = specialization;

//            return await _accountRepo.UpdateUser(user);
//        }
//    }
//}
