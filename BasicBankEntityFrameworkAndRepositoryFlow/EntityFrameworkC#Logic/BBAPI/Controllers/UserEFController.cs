using AutoMapper;
using BBAPI.Data;
using BBAPI.Dtos;
using BBAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{   
    IUserRepository _userRepository;
    IMapper _mapper;

    public UserEFController(IConfiguration config, IUserRepository userRepository)
    {
        _userRepository = userRepository;

        _mapper = new Mapper(new MapperConfiguration(cfg =>{
            cfg.CreateMap<UserToAddDto, User>();
            cfg.CreateMap<Account, Account>().ReverseMap();
            cfg.CreateMap<Loan, Loan>().ReverseMap();
        }));

    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _userRepository.GetUsers();
        return users;
    }

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        return _userRepository.GetSingleUser(userId);
    }
    
    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userDb = _userRepository.GetSingleUser(user.UserId);
            
        if (userDb != null)
        {
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            if (_userRepository.SaveChanges())
            {
                return Ok();
            } 

            throw new Exception("Failed to Update User");
        }
        
        throw new Exception("Failed to Get User");
    }


    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddDto user)
    {
        User userDb = _mapper.Map<User>(user);
        
        _userRepository.AddEntity<User>(userDb);
        if (_userRepository.SaveChanges())
        {
            return Ok();
        } 

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _userRepository.GetSingleUser(userId);
            
        if (userDb != null)
        {
            _userRepository.RemoveEntity<User>(userDb);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            } 

            throw new Exception("Failed to Delete User");
        }
        
        throw new Exception("Failed to Get User");
    }

    [HttpGet("Account/{userId}")]
    public Account GetAccountEF(int userId)
    {
        return _userRepository.GetSingleAccount(userId);
    }

    [HttpPost("Account")]
    public IActionResult PostAccountEf(Account userForInsert)
    {
        _userRepository.AddEntity<Account>(userForInsert);
        if (_userRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Adding Account failed on save");
    }


    [HttpPut("Account")]
    public IActionResult PutAccountEf(Account userForUpdate)
    {
        Account? userToUpdate = _userRepository.GetSingleAccount(userForUpdate.UserId);

        if (userToUpdate != null)
        {
            _mapper.Map(userForUpdate, userToUpdate);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Updating Account failed on save");
        }
        throw new Exception("Failed to find Account to Update");
    }


    [HttpDelete("Account/{userId}")]
    public IActionResult DeleteAccountEf(int userId)
    {
        Account? userToDelete = _userRepository.GetSingleAccount(userId);

        if (userToDelete != null)
        {
            _userRepository.RemoveEntity<Account>(userToDelete);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Deleting Account failed on save");
        }
        throw new Exception("Failed to find Account to delete");
    }


    [HttpGet("Loan/{userId}")]
    public Loan GetLoanEF(int userId)
    {
        return _userRepository.GetSingleLoan(userId);
    }

    [HttpPost("Loan")]
    public IActionResult PostLoanEf(Loan userForInsert)
    {
        _userRepository.AddEntity<Loan>(userForInsert);
        if (_userRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Adding Loan failed on save");
    }


    [HttpPut("Loan")]
    public IActionResult PutLoanEf(Loan userForUpdate)
    {
        Loan? userToUpdate = _userRepository.GetSingleLoan(userForUpdate.UserId);

        if (userToUpdate != null)
        {
            _mapper.Map(userForUpdate, userToUpdate);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Updating Loan failed on save");
        }
        throw new Exception("Failed to find Loan to Update");
    }


    [HttpDelete("Loan/{userId}")]
    public IActionResult DeleteLoanEf(int userId)
    {
        Loan? userToDelete = _userRepository.GetSingleLoan(userId);

        if (userToDelete != null)
        {
            _userRepository.RemoveEntity<Loan>(userToDelete);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Deleting Loan failed on save");
        }
        throw new Exception("Failed to find Loan to delete");
    }
}
