using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class VpcClient : IVpcClient {
        private readonly IConnection _connection;

        public VpcClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To list all of the VPCs on your account.
        /// </summary>
        public Task<IReadOnlyList<Vpc>> GetAll() {
            return _connection.GetPaginated<Vpc>("vpcs", null, "vpcs");
        }

        /// <summary>
        /// To create a VPC.
        /// </summary>
        public Task<Vpc> Create(Models.Requests.Vpc vpc) {
            return _connection.ExecuteRequest<Vpc>("vpcs", null, vpc, "vpc", Method.Post);
        }

        /// <summary>
        /// To show information about an existing VPC.
        /// </summary>
        public Task<Vpc> Get(string vpcId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("id", vpcId)
            };
            return _connection.ExecuteRequest<Vpc>("vpcs/{id}", parameters, null, "vpc");
        }

        /// <summary>
        /// To delete a VPC.
        /// The default VPC for a region can not be deleted.
        /// Additionally, a VPC can only be deleted if it does not contain any member resources.
        /// Attempting to delete a region's default VPC or a VPC that still has members will result in an error response.
        /// </summary>
        public Task Delete(string vpcId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", vpcId)
            };
            return _connection.ExecuteRaw("vpcs/{id}", parameters, null, Method.Delete);
        }

        /// <summary>
        /// To update information about a VPC.
        /// Currently, only the name and description attributes can be updated.
        /// Excluding an attribute will reset it to its default.
        /// </summary>
        public Task<Vpc> Update(string vpcId, Models.Requests.UpdateVpc updateVpc) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", vpcId)
            };
            return _connection.ExecuteRequest<Vpc>("vpcs/{id}", parameters, updateVpc, "vpc", Method.Put);
        }

        /// <summary>
        /// To update a subset of information about a VPC.
        /// Currently, only the name and description attributes can be updated.
        /// </summary>
        public Task<Vpc> PartialUpdate(string vpcId, Models.Requests.UpdateVpc updateVpc) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", vpcId)
            };
            return _connection.ExecuteRequest<Vpc>("vpcs/{id}", parameters, updateVpc, "vpc", Method.Patch);
        }

        /// <summary>
        /// To list all of the resources that are members of a VPC.
        /// To only list resources of a specific type that are members of the VPC, included a resource_type query parameter.
        /// </summary>
        public Task<IReadOnlyList<VpcMember>> ListMembers(string vpcId, string resourceType = null) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id", vpcId)
            };
            if (!String.IsNullOrEmpty(resourceType)) {
                parameters.Add(new QueryParameter("resource_type", resourceType));
            }
            return _connection.GetPaginated<VpcMember>("vpcs/{id}/members", parameters, "members");
        }
    }
}
