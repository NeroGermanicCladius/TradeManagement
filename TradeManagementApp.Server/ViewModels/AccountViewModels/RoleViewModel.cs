using System.ComponentModel.DataAnnotations;

namespace TradeManagementApp.Server.ViewModels.AccountViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleValue { get; set; }
        
        [Required]
        public LoginViewModel LoginModel { get; set; }
    }
}
