using DNATestingSystem.GrpcService.ThinhLC.Protos;
using DNATestingSystem.Services.ThinhLC;
using Grpc.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DNATestingSystem.GrpcService.ThinhLC.Services
{
    public class SampleThinhLCGrpcService : SampleThinhLCGRPC.SampleThinhLCGRPCBase
    {
        private readonly ISampleThinhLCService _sampleService;

        public SampleThinhLCGrpcService(ISampleThinhLCService sampleService)
        {
            _sampleService = sampleService;
        }

        public override async Task<SampleThinhLCList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            try
            {
                var result = new SampleThinhLCList();
                var samples = await _sampleService.GetAllAsync();
                foreach (var sample in samples)
                {
                    var grpcSample = new SampleThinhLc
                    {
                        SampleThinhLcid = sample.SampleThinhLcid ?? 0,
                        ProfileThinhLcid = sample.ProfileThinhLcid ?? 0,
                        SampleTypeThinhLcid = sample.SampleTypeThinhLcid ?? 0,
                        AppointmentsTienDmid = sample.AppointmentsTienDmid ?? 0,
                        Notes = sample.Notes ?? string.Empty,
                        IsProcessed = sample.IsProcessed ?? false,
                        Count = sample.Count ?? 0,
                        CollectedAt = sample.CollectedAt?.ToString("o") ?? string.Empty,
                        CreatedAt = sample.CreatedAt?.ToString("o") ?? string.Empty,
                        UpdatedAt = sample.UpdatedAt?.ToString("o") ?? string.Empty,
                        DeletedAt = sample.DeletedAt?.ToString("o") ?? string.Empty
                    };
                    result.Items.Add(grpcSample);
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, "An error occurred while processing the request."));
            }
        }

        public override async Task<SampleThinhLc> GetById(SampleThinhLcIDRequest request, ServerCallContext context)
        {
            try
            {
                var sample = await _sampleService.GetByIdAsync(request.SampleThinhLcid);

                if (sample == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Sample not found."));
                }

                var grpcSample = new SampleThinhLc
                {
                    SampleThinhLcid = sample.SampleThinhLcid ?? 0,
                    ProfileThinhLcid = sample.ProfileThinhLcid ?? 0,
                    SampleTypeThinhLcid = sample.SampleTypeThinhLcid ?? 0,
                    AppointmentsTienDmid = sample.AppointmentsTienDmid ?? 0,
                    Notes = sample.Notes ?? string.Empty,
                    IsProcessed = sample.IsProcessed ?? false,
                    Count = sample.Count ?? 0,
                    CollectedAt = sample.CollectedAt?.ToString("o") ?? string.Empty,
                    CreatedAt = sample.CreatedAt?.ToString("o") ?? string.Empty,
                    UpdatedAt = sample.UpdatedAt?.ToString("o") ?? string.Empty,
                    DeletedAt = sample.DeletedAt?.ToString("o") ?? string.Empty
                };

                return grpcSample;
            }
            catch (RpcException)
            {
                throw; // Re-throw gRPC exceptions as they are
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, "An error occurred while processing the request."));
            }
        }

        public override async Task<CreateResponse> Create(SampleThinhLc request, ServerCallContext context)
        {
            try
            {
                var now = DateTime.Now;
                var sample = new DNATestingSystem.Repository.ThinhLC.Models.SampleThinhLc
                {
                    // Do NOT set SampleThinhLcid for new records, let the DB auto-generate it
                    ProfileThinhLcid = request.ProfileThinhLcid,
                    SampleTypeThinhLcid = request.SampleTypeThinhLcid,
                    AppointmentsTienDmid = request.AppointmentsTienDmid,
                    Notes = request.Notes ?? string.Empty,
                    IsProcessed = request.IsProcessed,
                    Count = request.Count,
                    CollectedAt = now,
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = now
                };
                var id = await _sampleService.CreateAsync(sample);
                return new CreateResponse { Id = id, Success = true, Message = "Created successfully" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Create: {ex}");
                return new CreateResponse { Id = 0, Success = false, Message = $"Error: {ex.Message} | {ex.InnerException?.Message}" };
            }
        }

        public override async Task<UpdateResponse> Update(SampleThinhLc request, ServerCallContext context)
        {
            try
            {
                var now = DateTime.Now;
                var sample = new DNATestingSystem.Repository.ThinhLC.Models.SampleThinhLc();
                // Map fields from proto to entity
                sample.SampleThinhLcid = request.SampleThinhLcid;
                sample.ProfileThinhLcid = request.ProfileThinhLcid;
                sample.SampleTypeThinhLcid = request.SampleTypeThinhLcid;
                sample.AppointmentsTienDmid = request.AppointmentsTienDmid;
                sample.Notes = request.Notes ?? string.Empty;
                sample.IsProcessed = request.IsProcessed;
                sample.Count = request.Count;
                sample.CollectedAt = now;
                sample.CreatedAt = now;
                sample.UpdatedAt = now;
                sample.DeletedAt = now;

                var result = await _sampleService.UpdateAsync(sample);
                return new UpdateResponse { AffectedRows = result, Success = result > 0, Message = result > 0 ? "Updated successfully" : "No record updated" };
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"[Update Error] {ex.Message}");
                return new UpdateResponse { AffectedRows = 0, Success = false, Message = $"ArgumentNullException: {ex.Message} (check for null proto string fields)" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Update Error] {ex.Message}");
                return new UpdateResponse { AffectedRows = 0, Success = false, Message = $"Error: {ex.Message} | {ex.InnerException?.Message}" };
            }
        }

        public override async Task<DeleteResponse> Delete(SampleThinhLcIDRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _sampleService.RemoveAsync(request.SampleThinhLcid);
                return new DeleteResponse { Success = result, Message = result ? "Deleted successfully" : "Delete failed" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return new DeleteResponse { Success = false, Message = "An error occurred while deleting the sample." };
            }
        }
    }
}
