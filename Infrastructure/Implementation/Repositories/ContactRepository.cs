using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.Contact;
using DTO.Request.Header;
using DTO.Response.Contact;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public ContactRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<int> CreateUpdateContact(ContactRequestDto contactRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateContact",
            _parameterManager.Get("@Id", contactRequestDto.Id),
            _parameterManager.Get("@Address_1_City", contactRequestDto.Address_1_City),
            _parameterManager.Get("@Address_1_Postal_Code", contactRequestDto.Address_1_Postal_Code),
            _parameterManager.Get("@Address_1_Region", contactRequestDto.Address_1_Region),
            _parameterManager.Get("@Address_1_Street", contactRequestDto.Address_1_Street),
            _parameterManager.Get("@E_mail_1_Value", contactRequestDto.E_mail_1_Value),
            _parameterManager.Get("@Family_Name  ", contactRequestDto.Family_Name),
            _parameterManager.Get("@Given_Name   ", contactRequestDto.Given_Name),
            _parameterManager.Get("@Phone_1_Value", contactRequestDto.Phone_1_Value),
            _parameterManager.Get("@Phone_2_Value", contactRequestDto.Phone_2_Value),
            _parameterManager.Get("@Phone_3_Value", contactRequestDto.Phone_3_Value),
            _parameterManager.Get("@Phone_4_Value", contactRequestDto.Phone_4_Value),
            _parameterManager.Get("@Phone_5_Value", contactRequestDto.Phone_5_Value),
            _parameterManager.Get("@Phone_6_Value", contactRequestDto.Phone_6_Value)
            );
        }

        public async Task<(List<ContactResponseDto>, int)> GetAllContact(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<ContactResponseDto> contact;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                
                    var result = await dbConnection.QueryMultipleAsync(
                "usp_hatzalah_GetAllContact", _dbContext.GetDapperDynamicParameters
                (_parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText)
                ),
                commandType: CommandType.StoredProcedure);
                    total = result.Read<int>().FirstOrDefault();
                    contact = result.Read<ContactResponseDto>().ToList();
                    dbConnection.Close();
            }
            return (contact, total);
        }

        public async Task<List<ContactSearchResponse>> SearchContacts(ContactSearchRequestDto contactSearchRequestDto)
        {
            List<ContactSearchResponse> contactSearches;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_SearchContact", _dbContext.GetDapperDynamicParameters(
                _parameterManager.Get("Search", contactSearchRequestDto.searchText),
                _parameterManager.Get("IsFromChat", contactSearchRequestDto.IsFromChat),
                    _parameterManager.Get("IsOnlyMember", contactSearchRequestDto.IsOnlyMember),
                _parameterManager.Get("IsFromBria", contactSearchRequestDto.isFromBria),
                    _parameterManager.Get("AlsoMembersFromContactSearch", contactSearchRequestDto.alsoMembersFromContactSearch)
                    ),
                    commandType: CommandType.StoredProcedure);
                contactSearches = result.Read<ContactSearchResponse>().ToList();
                dbConnection.Close();
            }
            return (contactSearches);
        }

        public async Task<Contacts> GetContactById(int Id)
        {
            return await _dbContext.ExecuteStoredProcedure<Contacts>("usp_hatzalah_GetContactById",
           _parameterManager.Get("@ContactId", Id));
        }
    }
}
