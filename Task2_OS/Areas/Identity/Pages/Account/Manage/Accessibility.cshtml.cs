using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task2_OS.Data;
using System.Threading.Tasks;

public class AccessibilityDataModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccessibilityDataModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> OnPostUpdateAccessibilitySettingsAsync(string theme, bool enableAccessibility)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            user.Theme = theme;
            user.AccessibilityWidgetEnabled = enableAccessibility;
            var result = await _userManager.UpdateAsync(user);
        }
        else
        {
            //user not found
        }

        return RedirectToPage();

    }
}



