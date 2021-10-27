using System.Threading.Tasks;
using Grpc.Core;
using Ozon.MerchandiseService.Grpc;

namespace Ozon.MerchandiseService.Presentation.GrpcServices
{
    public class MerchandiseServiceGrpcService : MerchandiseApiGrpc.MerchandiseApiGrpcBase
    {
        public override async Task<GetMerchResponse> GetMerch(GetMerchRequest request, ServerCallContext context)
        {
            return new GetMerchResponse();
        }

        public override async Task<GetInfoAboutMerchResponse> GetInfoAboutMerch(GetInfoAboutMerchRequest request, ServerCallContext context)
        {
            return new GetInfoAboutMerchResponse();
        }
    }
}