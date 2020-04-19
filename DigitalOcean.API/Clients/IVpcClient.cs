using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IVpcClient {
        /// <summary>
        /// To list all of the VPCs on your account.
        /// </summary>
        Task<IReadOnlyList<Vpc>> GetAll();

        /// <summary>
        /// To create a VPC.
        /// </summary>
        Task<Vpc> Create(Models.Requests.Vpc vpc);

        /// <summary>
        /// To show information about an existing VPC.
        /// </summary>
        Task<Vpc> Get(string vpcId);

        /// <summary>
        /// To delete a VPC.
        /// The default VPC for a region can not be deleted.
        /// Additionally, a VPC can only be deleted if it does not contain any member resources.
        /// Attempting to delete a region's default VPC or a VPC that still has members will result in an error response.
        /// </summary>
        Task Delete(string vpcId);

        /// <summary>
        /// To update information about a VPC.
        /// Currently, only the name and description attributes can be updated.
        /// Excluding an attribute will reset it to its default.
        /// </summary>
        Task<Vpc> Update(string vpcId, Models.Requests.UpdateVpc updateVpc);

        /// <summary>
        /// To update a subset of information about a VPC.
        /// Currently, only the name and description attributes can be updated.
        /// </summary>
        Task<Vpc> PartialUpdate(string vpcId, Models.Requests.UpdateVpc updateVpc);

        /// <summary>
        /// To list all of the resources that are members of a VPC.
        /// To only list resources of a specific type that are members of the VPC, included a resource_type query parameter.
        /// </summary>
        Task<IReadOnlyList<VpcMember>> ListMembers(string vpcId, string resourceType = null);
    }
}
