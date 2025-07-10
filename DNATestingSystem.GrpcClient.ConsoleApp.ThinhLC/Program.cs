using DNATestingSystem.GrpcService.ThinhLC.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static SampleThinhLCGRPC.SampleThinhLCGRPCClient? sampleClient;
    static SampleTypeThinhLCGRPC.SampleTypeThinhLCGRPCClient? sampleTypeClient;
    static GrpcChannel? channel;

    static async Task Main(string[] args)
    {
        channel = GrpcChannel.ForAddress("https://localhost:7265");
        sampleClient = new SampleThinhLCGRPC.SampleThinhLCGRPCClient(channel);
        sampleTypeClient = new SampleTypeThinhLCGRPC.SampleTypeThinhLCGRPCClient(channel);
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. SampleThinhLc CRUD");
            Console.WriteLine("2. SampleTypeThinhLc CRUD");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
            var mainChoice = Console.ReadLine();
            switch (mainChoice)
            {
                case "1":
                    await SampleThinhLcCrud(sampleClient);
                    break;
                case "2":
                    await SampleTypeThinhLcCrud(sampleTypeClient);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        channel?.Dispose();
    }

    static async Task SampleThinhLcCrud(SampleThinhLCGRPC.SampleThinhLCGRPCClient client)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- SampleThinhLC CRUD ---");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Get by ID");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var allResponse = client.GetAllAsync(new EmptyRequest());
                    foreach (var s in allResponse.Items)
                    {
                        Console.WriteLine($"ID: {s.SampleThinhLcid}, Notes: {s.Notes}, Count: {s.Count}, isProcessed: {s.IsProcessed}, CollectedAt: {s.CollectedAt}, CreatedAt: {s.CreatedAt}, UpdatedAt: {s.UpdatedAt}, DeletedAt: {s.DeletedAt}");
                    }
                    break;
                case "2":
                    Console.Write("Enter ID: ");
                    if (int.TryParse(Console.ReadLine(), out int gid))
                    {
                        var item = await client.GetByIdAsync(new SampleThinhLcIDRequest { SampleThinhLcid = gid });
                        if (item != null && item.SampleThinhLcid != 0)
                        {
                            Console.WriteLine($"ID: {item.SampleThinhLcid}, Notes: {item.Notes}, Count: {item.Count}, isProcessed: {item.IsProcessed}, CollectedAt: {item.CollectedAt}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}, DeletedAt: {item.DeletedAt}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "3":
                    var create = new SampleThinhLc();
                    Console.Write("ProfileThinhLcid: "); create.ProfileThinhLcid = int.TryParse(Console.ReadLine(), out int pid) ? pid : 0;
                    Console.Write("SampleTypeThinhLcid: "); create.SampleTypeThinhLcid = int.TryParse(Console.ReadLine(), out int stid) ? stid : 0;
                    Console.Write("AppointmentsTienDmid: "); create.AppointmentsTienDmid = int.TryParse(Console.ReadLine(), out int aid) ? aid : 0;
                    Console.Write("Notes: "); create.Notes = Console.ReadLine();
                    Console.Write("IsProcessed (true/false): "); var isProc = Console.ReadLine(); create.IsProcessed = bool.TryParse(isProc, out bool ip) ? ip : false;
                    Console.Write("Count: "); create.Count = int.TryParse(Console.ReadLine(), out int c) ? c : 0;
                    create.CollectedAt = DateTime.Now.ToString("o");
                    create.CreatedAt = DateTime.Now.ToString("o");
                    create.UpdatedAt = DateTime.Now.ToString("o");
                    create.DeletedAt = string.Empty;
                    var cr = await client.CreateAsync(create);
                    Console.WriteLine($"Created, result: {cr.Message}");
                    break;
                case "4":
                    Console.Write("Enter ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int uid))
                    {
                        var up = await client.GetByIdAsync(new SampleThinhLcIDRequest { SampleThinhLcid = uid });
                        if (up != null && up.SampleThinhLcid != 0)
                        {
                            string pidStr, stidStr, aidStr, isProcStr, cntStr;
                            Console.Write($"ProfileThinhLcid ({up.ProfileThinhLcid}): "); pidStr = Console.ReadLine(); if (int.TryParse(pidStr, out int pidVal)) up.ProfileThinhLcid = pidVal;
                            Console.Write($"SampleTypeThinhLcid ({up.SampleTypeThinhLcid}): "); stidStr = Console.ReadLine(); if (int.TryParse(stidStr, out int stidVal)) up.SampleTypeThinhLcid = stidVal;
                            Console.Write($"AppointmentsTienDmid ({up.AppointmentsTienDmid}): "); aidStr = Console.ReadLine(); if (int.TryParse(aidStr, out int aidVal)) up.AppointmentsTienDmid = aidVal;
                            Console.Write($"Notes ({up.Notes}): "); var n = Console.ReadLine(); if (!string.IsNullOrEmpty(n)) up.Notes = n;
                            Console.Write($"IsProcessed ({up.IsProcessed}): "); isProcStr = Console.ReadLine(); if (bool.TryParse(isProcStr, out bool ipVal)) up.IsProcessed = ipVal;
                            Console.Write($"Count ({up.Count}): "); cntStr = Console.ReadLine(); if (int.TryParse(cntStr, out int cntVal)) up.Count = cntVal;
                            up.UpdatedAt = DateTime.Now.ToString("o");
                            var ur = await client.UpdateAsync(up);
                            Console.WriteLine($"Updated, result: {ur.Message}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int did))
                    {
                        var dr = await client.DeleteAsync(new SampleThinhLcIDRequest { SampleThinhLcid = did });
                        Console.WriteLine($"Deleted, result: {dr.Message}");
                    }
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static async Task SampleTypeThinhLcCrud(SampleTypeThinhLCGRPC.SampleTypeThinhLCGRPCClient client)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- SampleTypeThinhLC CRUD ---");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Get by ID");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var allResponse = client.GetAllAsync(new EmptyRequest());
                    foreach (var s in allResponse.Items)
                    {
                        Console.WriteLine($"ID: {s.SampleTypeThinhLcid}, Name: {s.Name}, Description: {s.Description}, CreatedAt: {s.CreatedAt}, UpdatedAt: {s.UpdatedAt}, DeletedAt: {s.DeletedAt}");
                    }
                    break;
                case "2":
                    Console.Write("Enter ID: ");
                    if (int.TryParse(Console.ReadLine(), out int gid))
                    {
                        var item = await client.GetByIdAsync(new SampleTypeThinhLcIDRequest { SampleTypeThinhLcid = gid });
                        if (item != null && item.SampleTypeThinhLcid != 0)
                        {
                            Console.WriteLine($"ID: {item.SampleTypeThinhLcid}, Name: {item.Name}, Description: {item.Description}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}, DeletedAt: {item.DeletedAt}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "3":
                    var create = new SampleTypeThinhLc();
                    Console.Write("Name: "); create.Name = Console.ReadLine();
                    Console.Write("Description: "); create.Description = Console.ReadLine();
                    create.CreatedAt = DateTime.Now.ToString("o");
                    create.UpdatedAt = DateTime.Now.ToString("o");
                    create.DeletedAt = string.Empty;
                    var cr = await client.CreateAsync(create);
                    Console.WriteLine($"Created, result: {cr.Message}");
                    break;
                case "4":
                    Console.Write("Enter ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int uid))
                    {
                        var up = await client.GetByIdAsync(new SampleTypeThinhLcIDRequest { SampleTypeThinhLcid = uid });
                        if (up != null && up.SampleTypeThinhLcid != 0)
                        {
                            string nameStr, descStr;
                            Console.Write($"Name ({up.Name}): "); nameStr = Console.ReadLine(); if (!string.IsNullOrEmpty(nameStr)) up.Name = nameStr;
                            Console.Write($"Description ({up.Description}): "); descStr = Console.ReadLine(); if (!string.IsNullOrEmpty(descStr)) up.Description = descStr;
                            up.UpdatedAt = DateTime.Now.ToString("o");
                            var ur = await client.UpdateAsync(up);
                            Console.WriteLine($"Updated, result: {ur.Message}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int did))
                    {
                        var dr = await client.DeleteAsync(new SampleTypeThinhLcIDRequest { SampleTypeThinhLcid = did });
                        Console.WriteLine($"Deleted, result: {dr.Message}");
                    }
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}