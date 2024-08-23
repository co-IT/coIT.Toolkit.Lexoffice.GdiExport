using System.Text;
using Newtonsoft.Json;

namespace coIT.Lexoffice.GdiExport.Helpers;

internal class JsonRepository<T>
    where T : class, new()
{
    private readonly string _filename;

    public JsonRepository(string filename)
    {
        _filename = filename;
    }

    public async Task<IList<T>> List()
    {
        var json = await File.ReadAllTextAsync(_filename, Encoding.UTF8);

        var elements = JsonConvert.DeserializeObject<List<T>>(json);

        return elements ?? new List<T>();
    }

    public async void Save(IEnumerable<T> elements)
    {
        var serializedCustomerList = JsonConvert.SerializeObject(elements);
        await File.WriteAllTextAsync(_filename, serializedCustomerList, Encoding.UTF8);
    }
}
