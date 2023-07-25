using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Upkeep.Models;
using Upkeep.Repositories;


namespace Upkeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        [Authorize]
        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserProfile(string firebaseUserId)
        {
            return Ok(_userProfileRepository.GetByFirebaseUserId(firebaseUserId));
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var userProfile = _userProfileRepository.GetByFirebaseUserId(firebaseUserId);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        [Authorize]
        [HttpGet("details/{id}")]
        public IActionResult GetById(int id)
        {
            var userProfile = _userProfileRepository.GetById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            _userProfileRepository.Add(userProfile);
            return CreatedAtAction(
                nameof(GetUserProfile),
                new { firebaseUserId = userProfile.FirebaseUserId },
                userProfile);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            var verifiedCurrentUserProfile = GetCurrentUserProfile();

            if (id != userProfile.Id || verifiedCurrentUserProfile.Id != userProfile.Id)
            {
                return BadRequest();
            }
            _userProfileRepository.Update(userProfile);
            return Ok();
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
