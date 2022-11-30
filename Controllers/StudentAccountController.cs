using labb04_KPZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace labb04_KPZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentAccountController : ControllerBase
    {
        private readonly StudentAccountContext _studentAccountContext;

        public StudentAccountController(StudentAccountContext context)
        {
            _studentAccountContext = context;
        }

        #region Create
        [HttpPost]
        [Route("Account")]
        public async Task<IActionResult> AddAccount(string loggin, string password)
        {
            try
            {
                _studentAccountContext.Accounts.Add(new () { Loggin = loggin, Password = password });
                await _studentAccountContext.SaveChangesAsync();
                return Ok(_studentAccountContext.Accounts.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Student")]
        public async Task<IActionResult> AddStudent(string name, string surname, int age, string institute, string group, int number, int accountId)
        {
            try
            {
                _studentAccountContext.Students.Add(
                    new () { Name = name, Surname = surname, Age = age, Institute = institute, Group = group, Num = number, 
                        Account = _studentAccountContext.Accounts.Where(s => s.Id == accountId).FirstOrDefault(), AccountId = accountId });

                await _studentAccountContext.SaveChangesAsync();
                return Ok(_studentAccountContext.Students.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Read
        [HttpGet]
        [Route("Account")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<Account> accounts = _studentAccountContext.Accounts.ToList();
                if (accounts != null)
                    return Ok(accounts);
                return Ok("There`re not Accounts in DB");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Student")]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                List<Student> accounts = _studentAccountContext.Students.ToList();
                if (accounts != null)
                    return Ok(accounts);
                return Ok("There`re not Students in DB");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Achievement")]
        public async Task<IActionResult> GetAchievement()
        {
            try
            {
                List<Achievement> accounts = _studentAccountContext.Achievements.ToList();
                if (accounts != null)
                    return Ok(accounts);
                return Ok("There`re not Achievements in DB");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Student")]
        public async Task<IActionResult> UpdateStudent(int id, string name, string surname, int age, string institute, string group, int number, int accountId)
        {
            try
            {
                var student = await _studentAccountContext.Students.FindAsync(id);
                if (student == null)
                    return BadRequest();
                student.Name = name;
                student.Surname = surname;
                student.Age = age;
                student.Institute = institute;
                student.Group = group;
                student.Num = number;
                student.AccountId = accountId;
                _studentAccountContext.Entry(student).State = EntityState.Modified;

                await _studentAccountContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        [HttpPut]
        [Route("Account")]
        public async Task<IActionResult> UpdateAccount(int id, string loggin, string password)
        {
            try
            {
                var account = await _studentAccountContext.Accounts.FindAsync(id);
                if (account == null)
                    return BadRequest();
                account.Loggin = loggin;
                account.Password = password;

                _studentAccountContext.Entry(account).State = EntityState.Modified;

                await _studentAccountContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        #endregion

        #region Delete
        [HttpDelete]
        [Route("Account")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _studentAccountContext.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _studentAccountContext.Accounts.Remove(account);
            await _studentAccountContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("Student")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentAccountContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentAccountContext.Students.Remove(student);
            await _studentAccountContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}  