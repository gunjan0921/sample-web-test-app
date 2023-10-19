using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace dotnetcoresample.Pages;

public class IndexModel : PageModel
{

    public string OSVersion { get { return RuntimeInformation.OSDescription; }  }
    public string vaultSecret => CreateSecretInKeyVault();

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    
    public string CreateSecretInKeyVault()
    {
        var client = new SecretClient(new Uri("https://exampleTestKeyVault.vault.azure.net/"), new DefaultAzureCredential());
        KeyVaultSecret secret = client.GetSecret("test-secret");
        return secret.Value;
    }

    public void OnGet()
    {        
    }
}
