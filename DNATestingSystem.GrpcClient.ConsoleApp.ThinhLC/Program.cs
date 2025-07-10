// using DNATestingSystem.GrpcService.ThinhLC.Protos;
// using Grpc.Net.Client;

// class Program
// {
//     private static SampleThinhLCGRPC.SampleThinhLCGRPCClient? client;
//     private static GrpcChannel? channel;

//     static async Task Main(string[] args)
//     {
//     //    Console.WriteLine("=== DNA Testing System - Sample Management ===");

//     //    // Initialize gRPC client
//     //    try
//     //    {
//     //        channel = GrpcChannel.ForAddress("https://localhost:7265");
//     //        client = new SampleThinhLCGRPC.SampleThinhLCGRPCClient(channel);
//     //        Console.WriteLine("Connected to gRPC service successfully!");
//     //    }
//     //    catch (Exception ex)
//     //    {
//     //        Console.WriteLine($"Failed to connect to gRPC service: {ex.Message}");
//     //        Console.WriteLine("Press any key to exit...");
//     //        Console.ReadKey();
//     //        return;
//     //    }

//     //    bool exit = false;
//     //    while (!exit)
//     //    {
//     //        ShowMenu();
//     //        var choice = Console.ReadLine();

//     //        switch (choice)
//     //        {
//     //            case "1":
//     //                await ShowAllSamples();
//     //                break;
//     //            case "2":
//     //                await ShowSampleDetail();
//     //                break;
//     //            case "3":
//     //                await CreateSample();
//     //                break;
//     //            case "4":
//     //                await UpdateSample();
//     //                break;
//     //            case "5":
//     //                await DeleteSample();
//     //                break;
//     //            case "6":
//     //                exit = true;
//     //                Console.WriteLine("Goodbye!");
//     //                break;
//     //            default:
//     //                Console.WriteLine("Invalid choice! Please try again.");
//     //                break;
//     //        }

//     //        if (!exit)
//     //        {
//     //            Console.WriteLine("\nPress any key to continue...");
//     //            Console.ReadKey();
//     //        }
//     //    }

//     //    // Cleanup
//     //    channel?.Dispose();
//     //}

//     //static void ShowMenu()
//     //{
//     //    Console.Clear();
//     //    Console.WriteLine("=== DNA Testing System - Sample Management ===");
//     //    Console.WriteLine("1. Show All Samples");
//     //    Console.WriteLine("2. Show Sample Detail");
//     //    Console.WriteLine("3. Create New Sample");
//     //    Console.WriteLine("4. Update Sample");
//     //    Console.WriteLine("5. Delete Sample");
//     //    Console.WriteLine("6. Exit");
//     //    Console.WriteLine("===============================================");
//     //    Console.Write("Please select an option (1-6): ");
//     //}

//     //static async Task ShowAllSamples()
//     //{
//     //    Console.WriteLine("\n=== All Samples ===");
//     //    try
//     //    {
//     //        var response = await client!.GetAllAsync(new EmptyRequest());

//     //        if (response != null && response.Items != null && response.Items.Count > 0)
//     //        {
//     //            Console.WriteLine($"Found {response.Items.Count} samples:\n");
//     //            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-20} {5,-10}",
//     //                "ID", "Profile ID", "Sample Type", "Appointment", "Notes", "Processed");
//     //            Console.WriteLine(new string('-', 85));

//     //            foreach (var item in response.Items)
//     //            {
//     //                Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-20} {5,-10}",
//     //                    item.SampleThinhLcid,
//     //                    item.ProfileThinhLcid,
//     //                    item.SampleTypeThinhLcid,
//     //                    item.AppointmentsTienDmid,
//     //                    item.Notes?.Length > 17 ? item.Notes.Substring(0, 17) + "..." : item.Notes,
//     //                    item.IsProcessed ? "Yes" : "No");
//     //            }
//     //        }
//     //        else
//     //        {
//     //            Console.WriteLine("No samples found.");
//     //        }
//     //    }
//     //    catch (Exception ex)
//     //    {
//     //        Console.WriteLine($"Error retrieving samples: {ex.Message}");
//     //    }
//     //}

//     //static async Task ShowSampleDetail()
//     //{
//     //    Console.WriteLine("\n=== Sample Detail ===");
//     //    Console.Write("Enter Sample ID: ");

//     //    if (int.TryParse(Console.ReadLine(), out int sampleId))
//     //    {
//     //        try
//     //        {
//     //            var request = new SampleThinhLcIDRequest { SampleThinhLcid = sampleId };
//     //            var response = await client!.GetById(request);

//     //            if (response != null)
//     //            {
//     //                Console.WriteLine("\n--- Sample Information ---");
//     //                Console.WriteLine($"Sample ID: {response.SampleThinhLcid}");
//     //                Console.WriteLine($"Profile ID: {response.ProfileThinhLcid}");
//     //                Console.WriteLine($"Sample Type ID: {response.SampleTypeThinhLcid}");
//     //                Console.WriteLine($"Appointment ID: {response.AppointmentsTienDmid}");
//     //                Console.WriteLine($"Notes: {response.Notes}");
//     //                Console.WriteLine($"Is Processed: {(response.IsProcessed ? "Yes" : "No")}");
//     //                Console.WriteLine($"Count: {response.Count}");
//     //                Console.WriteLine($"Collected At: {response.CollectedAt}");
//     //                Console.WriteLine($"Created At: {response.CreatedAt}");
//     //                Console.WriteLine($"Updated At: {response.UpdatedAt}");
//     //                Console.WriteLine($"Deleted At: {response.DeletedAt}");
//     //            }
//     //        }
//     //        catch (Exception ex)
//     //        {
//     //            Console.WriteLine($"Error retrieving sample detail: {ex.Message}");
//     //        }
//     //    }
//     //    else
//     //    {
//     //        Console.WriteLine("Invalid Sample ID!");
//     //    }
//     //}

//     //static async Task CreateSample()
//     //{
//     //    Console.WriteLine("\n=== Create New Sample ===");

//     //    try
//     //    {
//     //        var newSample = new SampleThinhLc();

//     //        Console.Write("Enter Profile ID: ");
//     //        if (int.TryParse(Console.ReadLine(), out int profileId))
//     //            newSample.ProfileThinhLcid = profileId;

//     //        Console.Write("Enter Sample Type ID: ");
//     //        if (int.TryParse(Console.ReadLine(), out int sampleTypeId))
//     //            newSample.SampleTypeThinhLcid = sampleTypeId;

//     //        Console.Write("Enter Appointment ID: ");
//     //        if (int.TryParse(Console.ReadLine(), out int appointmentId))
//     //            newSample.AppointmentsTienDmid = appointmentId;

//     //        Console.Write("Enter Notes: ");
//     //        newSample.Notes = Console.ReadLine() ?? "";

//     //        Console.Write("Enter Count: ");
//     //        if (int.TryParse(Console.ReadLine(), out int count))
//     //            newSample.Count = count;

//     //        Console.Write("Is Processed? (y/n): ");
//     //        var processed = Console.ReadLine()?.ToLower();
//     //        newSample.IsProcessed = processed == "y" || processed == "yes";

//     //        newSample.CollectedAt = DateTime.Now.ToString("o");
//     //        newSample.CreatedAt = DateTime.Now.ToString("o");

//     //        var response = await client!.Create(newSample);

//     //        if (response.Success)
//     //        {
//     //            Console.WriteLine($"Sample created successfully! ID: {response.Id}");
//     //        }
//     //        else
//     //        {
//     //            Console.WriteLine($"Failed to create sample: {response.Message}");
//     //        }
//     //    }
//     //    catch (Exception ex)
//     //    {
//     //        Console.WriteLine($"Error creating sample: {ex.Message}");
//     //    }
//     //}

//     //static async Task UpdateSample()
//     //{
//     //    Console.WriteLine("\n=== Update Sample ===");
//     //    Console.Write("Enter Sample ID to update: ");

//     //    if (int.TryParse(Console.ReadLine(), out int sampleId))
//     //    {
//     //        try
//     //        {
//     //            // First, get the existing sample
//     //            var getRequest = new SampleThinhLcIDRequest { SampleThinhLcid = sampleId };
//     //            var existingSample = await client!.GetById(getRequest);

//     //            if (existingSample != null)
//     //            {
//     //                Console.WriteLine("\nCurrent sample information:");
//     //                Console.WriteLine($"Profile ID: {existingSample.ProfileThinhLcid}");
//     //                Console.WriteLine($"Sample Type ID: {existingSample.SampleTypeThinhLcid}");
//     //                Console.WriteLine($"Appointment ID: {existingSample.AppointmentsTienDmid}");
//     //                Console.WriteLine($"Notes: {existingSample.Notes}");
//     //                Console.WriteLine($"Count: {existingSample.Count}");
//     //                Console.WriteLine($"Is Processed: {existingSample.IsProcessed}");

//     //                Console.WriteLine("\nEnter new values (press Enter to keep current value):");

//     //                Console.Write($"Profile ID ({existingSample.ProfileThinhLcid}): ");
//     //                var profileInput = Console.ReadLine();
//     //                if (!string.IsNullOrEmpty(profileInput) && int.TryParse(profileInput, out int profileId))
//     //                    existingSample.ProfileThinhLcid = profileId;

//     //                Console.Write($"Sample Type ID ({existingSample.SampleTypeThinhLcid}): ");
//     //                var sampleTypeInput = Console.ReadLine();
//     //                if (!string.IsNullOrEmpty(sampleTypeInput) && int.TryParse(sampleTypeInput, out int sampleTypeId))
//     //                    existingSample.SampleTypeThinhLcid = sampleTypeId;

//     //                Console.Write($"Appointment ID ({existingSample.AppointmentsTienDmid}): ");
//     //                var appointmentInput = Console.ReadLine();
//     //                if (!string.IsNullOrEmpty(appointmentInput) && int.TryParse(appointmentInput, out int appointmentId))
//     //                    existingSample.AppointmentsTienDmid = appointmentId;

//     //                Console.Write($"Notes ({existingSample.Notes}): ");
//     //                var notesInput = Console.ReadLine();
//     //                if (!string.IsNullOrEmpty(notesInput))
//     //                    existingSample.Notes = notesInput;

//     //                Console.Write($"Count ({existingSample.Count}): ");
//     //                var countInput = Console.ReadLine();
//     //                if (!string.IsNullOrEmpty(countInput) && int.TryParse(countInput, out int count))
//     //                    existingSample.Count = count;

//     //                Console.Write($"Is Processed ({existingSample.IsProcessed}) (y/n): ");
//     //                var processedInput = Console.ReadLine()?.ToLower();
//     //                if (!string.IsNullOrEmpty(processedInput))
//     //                    existingSample.IsProcessed = processedInput == "y" || processedInput == "yes";

//     //                existingSample.UpdatedAt = DateTime.Now.ToString("o");

//     //                var response = await client!.Update(existingSample);

//     //                if (response.Success)
//     //                {
//     //                    Console.WriteLine("Sample updated successfully!");
//     //                }
//     //                else
//     //                {
//     //                    Console.WriteLine($"Failed to update sample: {response.Message}");
//     //                }
//     //            }
//     //        }
//     //        catch (Exception ex)
//     //        {
//     //            Console.WriteLine($"Error updating sample: {ex.Message}");
//     //        }
//     //    }
//     //    else
//     //    {
//     //        Console.WriteLine("Invalid Sample ID!");
//     //    }
//     //}

//     //static async Task DeleteSample()
//     //{
//     //    Console.WriteLine("\n=== Delete Sample ===");
//     //    Console.Write("Enter Sample ID to delete: ");

//     //    if (int.TryParse(Console.ReadLine(), out int sampleId))
//     //    {
//     //        try
//     //        {
//     //            // First, show the sample to be deleted
//     //            var getRequest = new SampleThinhLcIDRequest { SampleThinhLcid = sampleId };
//     //            var existingSample = await client!.GetById(getRequest);

//     //            if (existingSample != null)
//     //            {
//     //                Console.WriteLine("\nSample to be deleted:");
//     //                Console.WriteLine($"Sample ID: {existingSample.SampleThinhLcid}");
//     //                Console.WriteLine($"Profile ID: {existingSample.ProfileThinhLcid}");
//     //                Console.WriteLine($"Notes: {existingSample.Notes}");

//     //                Console.Write("\nAre you sure you want to delete this sample? (y/n): ");
//     //                var confirmation = Console.ReadLine()?.ToLower();

//     //                if (confirmation == "y" || confirmation == "yes")
//     //                {
//     //                    var deleteRequest = new SampleThinhLcIDRequest { SampleThinhLcid = sampleId };
//     //                    var response = await client!.Delete(deleteRequest);

//     //                    if (response.Success)
//     //                    {
//     //                        Console.WriteLine("Sample deleted successfully!");
//     //                    }
//     //                    else
//     //                    {
//     //                        Console.WriteLine($"Failed to delete sample: {response.Message}");
//     //                    }
//     //                }
//     //                else
//     //                {
//     //                    Console.WriteLine("Delete operation cancelled.");
//     //                }
//     //            }
//     //        }
//     //        catch (Exception ex)
//     //        {
//     //            Console.WriteLine($"Error deleting sample: {ex.Message}");
//     //        }
//     //    }
//     //    else
//     //    {
//     //        Console.WriteLine("Invalid Sample ID!");
//     //    }
//     }
// }