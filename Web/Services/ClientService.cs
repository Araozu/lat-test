using System.Collections.Concurrent;
using Acide.Latesa.Web.Models;

namespace Acide.Latesa.Web.Services;

public class ClientService
{
    private readonly ConcurrentBag<Client> _clients = new();
    private int _nextId = 1;
    private readonly object _lock = new();

    public ClientService()
    {
        // Add some demo data
        AddClient(new Client 
        { 
            Name = "John Doe", 
            Email = "john.doe@example.com", 
            Phone = "555-0101",
            Company = "Acme Corp"
        });
        AddClient(new Client 
        { 
            Name = "Jane Smith", 
            Email = "jane.smith@example.com", 
            Phone = "555-0102",
            Company = "Tech Solutions Inc"
        });
        AddClient(new Client 
        { 
            Name = "Robert Johnson", 
            Email = "robert.j@example.com", 
            Phone = "555-0103",
            Company = "Global Enterprises"
        });
    }

    public IEnumerable<Client> GetAll()
    {
        return _clients.OrderBy(c => c.Name).ToList();
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    public void AddClient(Client client)
    {
        lock (_lock)
        {
            client.Id = _nextId++;
            client.CreatedAt = DateTime.Now;
            _clients.Add(client);
        }
    }

    public bool UpdateClient(Client client)
    {
        var existingClient = GetById(client.Id);
        if (existingClient == null)
            return false;

        existingClient.Name = client.Name;
        existingClient.Email = client.Email;
        existingClient.Phone = client.Phone;
        existingClient.Company = client.Company;
        return true;
    }

    public bool DeleteClient(int id)
    {
        var client = GetById(id);
        if (client == null)
            return false;

        lock (_lock)
        {
            var tempList = _clients.ToList();
            tempList.Remove(client);
            _clients.Clear();
            foreach (var c in tempList)
            {
                _clients.Add(c);
            }
        }
        return true;
    }
}
