using Microsoft.AspNetCore.Components;
namespace TodoAppBlazorWasm.Pages;
public partial class TodoList
{
[Inject] private HttpClient http {  get; set; }
    [Parameter]
    public int MyProperty { get; set; }
}