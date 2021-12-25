using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazorApp.Shared.Pages;

public class ItemModel
{
    [NotNull]
    public string Name { get; set; }

    [NotNull]
    public string Address { get; set; }

    [NotNull]
    public DateTime? DateTime { get; set; }
}

public partial class VaccinationPlace
{
    [NotNull]
    private List<ItemModel>? Items { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        Items = FillItems();
    }

    private List<ItemModel> FillItems()
    {
        var items = new List<ItemModel>();
        items.Add(new ItemModel()
        {
            DateTime = DateTime.Now,
            Name = "1",
            Address = "2"
        });

        return items;
    }
}
