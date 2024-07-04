using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace studentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
        public class studentController : ControllerBase
        {
            private static List<Student> STUDENTS = new List<Student>
        {
            new Student
            {
                id=1, firstName="Sara", secondName="Cohen", email="sara@gmail.com",
                address="Rabi Akiva", active=true, phone="0548459691", avgMarks=99,
                absenceDays=new AbsenceDays[]
                {
                    new AbsenceDays {date=new DateTime(2020, 12, 20), sumOfAbsenceDays=5},
                    new AbsenceDays {date=new DateTime(2019, 12, 20), sumOfAbsenceDays=1}
                },year=Year.firstYear,
            },
            new Student
            {
                id=2, firstName="Rachel", secondName="Levi", address="Rabi Akiva",
                active=false, email="leha@gmail.com", phone="0548459691", avgMarks=98,
                departureDate=new DateTime(2020, 12, 20),
                absenceDays=new AbsenceDays[]
                {
                    new AbsenceDays {date=new DateTime(2018, 12, 20), sumOfAbsenceDays=3},
                    new AbsenceDays {date=new DateTime(2019, 12, 20), sumOfAbsenceDays=2}
                },year=Year.secondYear,
            },
             new Student
            {
                id=3, firstName="Leha", secondName="Levi", address="Rabi Akiva",
                active=true, email="leha@gmail.com", phone="0548459691", avgMarks=98,
                departureDate=new DateTime(2020, 12, 20),
                absenceDays=new AbsenceDays[]
                {
                    new AbsenceDays {date=new DateTime(2018, 12, 20), sumOfAbsenceDays=3},
                    new AbsenceDays {date=new DateTime(2019, 12, 20), sumOfAbsenceDays=2}
                },year=Year.secondYear,
            }
        };
            // GET: api/<ValuesController>
            [HttpGet]
            public IEnumerable<Student> Get()
            {
                return STUDENTS;
            }


            // GET api/<ValuesController>/5


            [HttpGet("active")]
            public IEnumerable<Student> Get(bool active)
            {
                if (active)
                {
                    return STUDENTS.Where(x => x.active);
                }
                return STUDENTS;
            }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student student = STUDENTS.FirstOrDefault(s => s.id == id);
            if (student != null)
            {
                return student;
            }
            return STUDENTS.FirstOrDefault(); 
        }
        // POST api/<ValuesController>
        [HttpPost]
            public IActionResult Post([FromBody] Student studentToAdd)
            {
                studentToAdd.id = STUDENTS.Count + 1;
                STUDENTS.Add(studentToAdd);
                return Ok();
            }

            // PUT api/<ValuesController>/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Student studentToupdate)
            {
                Student s = STUDENTS.FirstOrDefault(s => s.id == id);
                if (s != null)
                {
                    s.id = id;
                    s.firstName = studentToupdate.firstName;
                    s.secondName = studentToupdate.secondName;
                    s.address = studentToupdate.address;
                    s.email = studentToupdate.email;
                    s.phone = studentToupdate.phone;
                    s.avgMarks = studentToupdate.avgMarks;
                    s.active = studentToupdate.active;
                    // s.departureDate = studentToupdate.departureDate;
                    s.korsId = studentToupdate.korsId;
                    //s.absenceDays = studentToupdate.absenceDays;
                    return Ok();
                }
                return NotFound();
            }
            // DELETE api/<ValuesController>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var studentToDelete = STUDENTS.FirstOrDefault(s => s.id == id);
                if (studentToDelete != null)
                {
                    STUDENTS.Remove(studentToDelete);
                    return Ok(); // או ניתן להחזיר כל מידע נוסף שרלוונטי
                }
                return NotFound(); // אם לא נמצא תלמיד עם ה־ID שצוין
            }
        }
    
}

