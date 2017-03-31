using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Dapper;
using GigHub.Models;

namespace GigHub.Controllers.Api
{
    public class DoctorsController : ApiController
    {
        private SqlConnection _conn;

        public DoctorsController()
        {
            _conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\_Sandbox\GigHub\GigHub\App_Data\aspnet-GigHub-20170307015550.mdf;Initial Catalog=aspnet-GigHub-20170307015550;Integrated Security=True");
        }

        // GET: api/Doctors
        [HttpGet]
        public List<Doctor> Get()
        {
            using (_conn)
            {
                string sql = "select d.ID, d.FirstName, d.LastName, d.Attitude, d.EmailAddress, d.MobilePhone, d.Pager from hlc_Doctor d ";
                sql += "where Attitude <> 0";

                _conn.Open();

                return _conn.Query<Doctor>(sql).ToList();

            }
        }

        // GET: api/Doctors/5
        [HttpGet]
        public Doctor Get(int id)
        {
            using (_conn)
            {
                string sql =
                    "select * from hlc_Doctor where ID=" + id + ";" +
                    "select ds.*, s.SpecialtyName from hlc_DoctorSpecialty ds left join hlc_Specialty s on s.ID = ds.SpecialtyID where ds.DoctorID = " + id + ";" +
                    "select dh.*, h.HospitalName from hlc_DoctorHospital dh left join hlc_Hospital h on h.ID = dh.HospitalID where dh.DoctorID = " + id + ";" +
                    "select dn.*, u.FirstName + ' ' + u.LastName as UserName from hlc_DoctorNote dn left join hlc_User u on u.UserID = dn.UserID where dn.DoctorID = " + id + ";";

                _conn.Open();
                var multi = _conn.QueryMultiple(sql);

                var doctor = multi.Read<Doctor>().FirstOrDefault();
                if (doctor != null)
                {
                    doctor.Specialties = multi.Read<DoctorSpecialty>().ToList();
                    doctor.Hospitals = multi.Read<DoctorHospital>().ToList();
                    doctor.Notes = multi.Read<DoctorNote>().ToList();
                }

                return doctor;

            }
        }

        // POST: api/Doctors
        [HttpPost]
        [ResponseType(typeof(Doctor))]
        [Route("api/Doctors")]
        public IHttpActionResult Post(Doctor d)
        {
            var doctor = new Doctor();
            doctor.FirstName = "jeff";
            doctor.LastName = "jeff";
            return Ok(doctor);
        }

        // PUT: api/Doctors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Doctors/5
        public void Delete(int id)
        {
        }
    }
}
