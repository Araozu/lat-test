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
        lock (_lock)
        {
            _clients.Add(new Client
            {
                Id = _nextId++,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "+1-555-0101",
                Company = "Tech Corp",
                CreatedDate = DateTime.Now.AddDays(-30)
            });
            _clients.Add(new Client
            {
                Id = _nextId++,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "+1-555-0102",
                Company = "Business Solutions Inc",
                CreatedDate = DateTime.Now.AddDays(-15)
            });
            _clients.Add(new Client
            {
                Id = _nextId++,
                Name = "Robert Johnson",
                Email = "robert.j@example.com",
                Phone = "+1-555-0103",
                Company = "Consulting Group",
                CreatedDate = DateTime.Now.AddDays(-7)
            });
        }
    }

    public Task<List<Client>> GetAllClientsAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_clients.OrderByDescending(c => c.CreatedDate).ToList());
        }
    }

    public Task<Client?> GetClientByIdAsync(int id)
    {
        lock (_lock)
        {
            return Task.FromResult(_clients.FirstOrDefault(c => c.Id == id));
        }
    }

    public Task<Client> CreateClientAsync(Client client)
    {
        lock (_lock)
        {
            client.Id = _nextId++;
            client.CreatedDate = DateTime.Now;
            _clients.Add(client);
            return Task.FromResult(client);
        }
    }

    public Task<bool> UpdateClientAsync(Client client)
    {
        lock (_lock)
        {
            var existingClient = _clients.FirstOrDefault(c => c.Id == client.Id);
            if (existingClient == null)
                return Task.FromResult(false);

            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;
            existingClient.Company = client.Company;
            return Task.FromResult(true);
        }
    }

    public Task<bool> DeleteClientAsync(int id)
    {
        lock (_lock)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return Task.FromResult(false);

            // ConcurrentBag doesn't support direct removal, so we need to recreate
            var updatedClients = _clients.Where(c => c.Id != id).ToList();
            _clients.Clear();
            foreach (var c in updatedClients)
            {
                _clients.Add(c);
            }
            return Task.FromResult(true);
        }
    }
}
