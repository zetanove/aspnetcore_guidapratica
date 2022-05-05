using Microsoft.AspNetCore.Components;

namespace BlazorAppWebAssembly1.Pages
{
    public partial class Ricerca
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "categoria")]
        public string[]? Categorie { get; set; }
    }
}
