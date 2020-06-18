using AutoMapper;
using CustomPolicyProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using topcoderattempt1.Data;
using topcoderattempt1.Dtos;
using topcoderattempt1.Models;

namespace topcoderattempt1.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepo _repository; //repository probably equivelent to _contect form previous project 
        private readonly IMapper _mapper;

        public AuthController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository; // this is depency injected value 
            _mapper = mapper;

        }

        [HttpGet]
        [Route("verifyEmail")]
        public IActionResult verifyEmail([FromQuery] string token, [FromQuery] bool? update)
        {
            if (update ?? false)
            {
                return (_repository.ChangeEmailRequest(token) ? Redirect(Constants.baseUrl) : Redirect(nameof(forgotPasswordAsync)));
            }

            if (_repository.VerifyEmail(token))
            {
                return Redirect(Constants.baseUrl);
            }
            else
            {
                return Redirect(nameof(forgotPasswordAsync));
            }

        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserAuthDto Usr)
        {
            var token = _repository.Login(_mapper.Map<UserModel>(Usr));

            if (token == null)
            {
                return BadRequest();
            }
            return Ok(new { access_token = token });

        }
        [HttpPost]
        [Route("register")]
        public ActionResult<IEnumerable<UserModel>> CreateUser(UserCreateDto user)
        {
            var model = _mapper.Map<UserModel>(user);

            _repository.RegisterUser(model);


            return Ok();
        }

        [HttpPut]
        [Route("securityQuestion")]
        [LoggedInRequired]

        public IActionResult UpdateSecurityQuestion(UpdateSecurityQuestionDto questions)
        {
            var x = User.Identity;

            _repository.UpdateSecurityQuestion(questions.question, questions.answer);
            return Ok();
         }

        [HttpGet]
        [Route("securityQuestion")]
        public IActionResult GetSecurityQuestion(string email)
        {
            string question = _repository.GetSecurityQuestion(email);
            if (question == null)
            {
                return BadRequest();
            } else
            {
                return Ok(question);
            }
        }

        [HttpPost]
        [Route("forgotPassword")]
        public async System.Threading.Tasks.Task<IActionResult> forgotPasswordAsync(string email, string securityQuestion, string securityQuestionReply)
        {
            try
            {
                bool ret = await _repository.forgotPasswordAsync(email, securityQuestion, securityQuestionReply);
                if (ret)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }
    }
}
