using DNATestingSystem.GrpcService.ThinhLC.Protos;
using DNATestingSystem.Services.ThinhLC;
using Grpc.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DNATestingSystem.GrpcService.ThinhLC.Services
{
    public class SampleTypeThinhLCGrpcService : SampleTypeThinhLCGRPC.SampleTypeThinhLCGRPCBase
    {
        private readonly ISampleTypeThinhLCService _service;

        public SampleTypeThinhLCGrpcService(ISampleTypeThinhLCService service)
        {
            _service = service;
        }

        public override async Task<SampleTypeThinhLCList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            try
            {
                var result = new SampleTypeThinhLCList();
                var items = await _service.GetAllAsync();
                foreach (var item in items)
                {
                    var grpcItem = new SampleTypeThinhLc
                    {
                        SampleTypeThinhLcid = item.SampleTypeThinhLcid ?? 0,
                        Name = item.TypeName ?? string.Empty,
                        Description = item.Description ?? string.Empty,
                        CreatedAt = item.CreatedAt?.ToString("o") ?? string.Empty,
                        UpdatedAt = item.UpdatedAt?.ToString("o") ?? string.Empty,
                        DeletedAt = item.DeletedAt?.ToString("o") ?? string.Empty
                    };
                    result.Items.Add(grpcItem);
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, "An error occurred while processing the request."));
            }
        }

        public override async Task<SampleTypeThinhLc> GetById(SampleTypeThinhLcIDRequest request, ServerCallContext context)
        {
            try
            {
                var item = await _service.GetByIdAsync(request.SampleTypeThinhLcid);
                if (item == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "SampleTypeThinhLc not found."));
                }
                var grpcItem = new SampleTypeThinhLc
                {
                    SampleTypeThinhLcid = item.SampleTypeThinhLcid ?? 0,
                    Name = item.TypeName ?? string.Empty, // Fix: use PascalCase property
                    Description = item.Description ?? string.Empty,
                    CreatedAt = item.CreatedAt?.ToString("o") ?? string.Empty,
                    UpdatedAt = item.UpdatedAt?.ToString("o") ?? string.Empty,
                    DeletedAt = item.DeletedAt?.ToString("o") ?? string.Empty
                };
                return grpcItem;
            }
            catch (RpcException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetById: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, "An error occurred while processing the request."));
            }
        }

        public override async Task<CreateResponse> Create(SampleTypeThinhLc request, ServerCallContext context)
        {
            try
            {
                var item = new DNATestingSystem.Repository.ThinhLC.Models.SampleTypeThinhLc
                {
                    SampleTypeThinhLcid = request.SampleTypeThinhLcid,
                    TypeName = request.Name,
                    Description = request.Description,
                    CreatedAt = string.IsNullOrEmpty($"{request.CreatedAt}") ? (DateTime?)null : DateTime.Parse($"{request.CreatedAt}"),
                    UpdatedAt = string.IsNullOrEmpty($"{request.UpdatedAt}") ? (DateTime?)null : DateTime.Parse($"{request.UpdatedAt}"),
                    DeletedAt = string.IsNullOrEmpty($"{request.DeletedAt}") ? (DateTime?)null : DateTime.Parse($"{request.DeletedAt}")
                };
                var id = await _service.CreateAsync(item);
                return new CreateResponse { Id = id, Success = true, Message = "Created successfully" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Create: {ex.Message}");
                return new CreateResponse { Id = 0, Success = false, Message = "An error occurred while creating the item." };
            }
        }

        public override async Task<UpdateResponse> Update(SampleTypeThinhLc request, ServerCallContext context)
        {
            try
            {
                var item = new DNATestingSystem.Repository.ThinhLC.Models.SampleTypeThinhLc
                {
                    SampleTypeThinhLcid = request.SampleTypeThinhLcid,
                    TypeName = request.Name,
                    Description = request.Description,
                    CreatedAt = string.IsNullOrEmpty($"{request.CreatedAt}") ? (DateTime?)null : DateTime.Parse($"{request.CreatedAt}"),
                    UpdatedAt = string.IsNullOrEmpty($"{request.UpdatedAt}") ? (DateTime?)null : DateTime.Parse($"{request.UpdatedAt}"),
                    DeletedAt = string.IsNullOrEmpty($"{request.DeletedAt}") ? (DateTime?)null : DateTime.Parse($"{request.DeletedAt}")
                };
                var affectedRows = await _service.UpdateAsync(item);
                return new UpdateResponse { AffectedRows = affectedRows, Success = affectedRows > 0, Message = affectedRows > 0 ? "Updated successfully" : "No record updated" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return new UpdateResponse { AffectedRows = 0, Success = false, Message = "An error occurred while updating the item." };
            }
        }

        public override async Task<DeleteResponse> Delete(SampleTypeThinhLcIDRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _service.RemoveAsync(request.SampleTypeThinhLcid);
                return new DeleteResponse { Success = result, Message = result ? "Deleted successfully" : "Delete failed" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return new DeleteResponse { Success = false, Message = "An error occurred while deleting the item." };
            }
        }
    }
}
