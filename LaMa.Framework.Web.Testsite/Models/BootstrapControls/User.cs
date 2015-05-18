using System;

namespace LaMa.Framework.Web.Testsite.Models.BootstrapControls
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public bool IsPremium { get; set; }
    }
}