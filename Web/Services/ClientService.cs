using Acide.Latesa.Web.Models;

namespace Acide.Latesa.Web.Services;

public class ClientService
{
    private readonly List<Client> _clients = new();
    private int _nextId = 1;

    public ClientService()
    {
        // Add some demo data
        _clients.AddRange(new[]
        {
            new Client
            {
                Id = _nextId++,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "+1-555-0101",
                Company = "Tech Corp",
                CreatedDate = DateTime.Now.AddDays(-30)
            },
            new Client
            {
                Id = _nextId++,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "+1-555-0102",
                Company = "Business Solutions Inc",
                CreatedDate = DateTime.Now.AddDays(-15)
            },
            new Client
            {
                Id = _nextId++,
                Name = "Robert Johnson",
                Email = "robert.j@example.com",
                Phone = "+1-555-0103",
                Company = "Consulting Group",
                CreatedDate = DateTime.Now.AddDays(-7)
            }
        });
    }

    public Task<List<Client>> GetAllClientsAsync()
    {
        return Task.FromResult(_clients.OrderByDescending(c => c.CreatedDate).ToList());
    }

    public Task<Client?> GetClientByIdAsync(int id)
    {
        return Task.FromResult(_clients.FirstOrDefault(c => c.Id == id));
    }

    public Task<Client> CreateClientAsync(Client client)
    {
        client.Id = _nextId++;
        client.CreatedDate = DateTime.Now;
        _clients.Add(client);
        return Task.FromResult(client);
    }

    public Task<bool> UpdateClientAsync(Client client)
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

    public Task<bool> DeleteClientAsync(int id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
            return Task.FromResult(false);

        _clients.Remove(client);
        return Task.FromResult(true);
    }
}
