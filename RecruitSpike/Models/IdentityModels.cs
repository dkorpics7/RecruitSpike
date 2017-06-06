using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitSpike.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //    //Add profile properties for the user here to be added to the ASPNETUSERS table
        //    [Required]
        //    public string FName { get; set; }
        //    [Required]
        //    public string LName { get; set; }
        //    [Required]
        //    public DateTime DateOfBirth { get; set; }
        //    [Required]
        //    public double Height { get; set; }
        //    [Required]
        //    public double Weight { get; set; }
        //    [Required]
        //    public int Dependents { get; set; }
        //    public string Title { get; set; }
        //    public string Branch { get; set; }
        //    public double AsvabScore { get; set; }
        //    public double PracticeScore { get; set; }

        //    [ForeignKey("Education")]
        //    public int EducationID { get; set; }
        //    public virtual Education Education { get; set; }

        //    [ForeignKey("MaritalStatus")]
        //    public int MaritalStatusID { get; set; }
        //    public virtual MaritalStatu MaritalStatus { get; set; }

        //    [ForeignKey("PriorService")]
        //    public int PriorServiceID { get; set; }
        //    public virtual PriorService PriorService { get; set; }

        //    [ForeignKey("Roadmap")]
        //    public int RoadmapID { get; set; }
        //    public virtual Roadmap Roadmap { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}