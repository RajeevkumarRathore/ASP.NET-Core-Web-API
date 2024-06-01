using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ShiftType;
using DTO.Response.ShiftType;
using DTO.Response;
using Helper;
using System.Xml;

namespace Infrastructure.Implementation.Services
{
    public class ShiftTypeService : IShiftTypeService
    {
        private readonly IShiftTypeRepository _shiftTypeRepository;
       
        public ShiftTypeService(IShiftTypeRepository shiftTypeRepository)
        {
            _shiftTypeRepository = shiftTypeRepository;
            
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>> GetAllShiftType(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (shiftType, total) = await _shiftTypeRepository.GetAllShiftType(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllShiftTypeResponseDto>(shiftType, total), 0);
        }
        public async Task<CommonResultResponseDto<string>> DeleteShiftType(DeleteShiftTypeRequestDto deleteShiftTypeRequestDto)
        {
            bool Id = await _shiftTypeRepository.DeleteShiftType(deleteShiftTypeRequestDto);
            if (Id)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>> CreateUpdateShiftType(CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto)
        {

            var returnvalue = await _shiftTypeRepository.IsExistShiftType(createUpdateShiftTypeRequestDto.ShiftTypeName, createUpdateShiftTypeRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var shiftType = await _shiftTypeRepository.CreateUpdateShiftType(createUpdateShiftTypeRequestDto, PhoneNumbersXML(createUpdateShiftTypeRequestDto));

                if (shiftType == 0)
                {
                    return CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }
        #region Private
        private static string PhoneNumbersXML(CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);

            foreach (var findNumbers in createUpdateShiftTypeRequestDto.ShiftTypePhoneNumber)
            {
                XmlNode shiftTypePhoneNumber = xmlDocument.CreateElement("ShiftTypePhoneNumber");
                XmlAttribute attribute = xmlDocument.CreateAttribute("Id");
                attribute.Value = findNumbers.Id.ToString();
                shiftTypePhoneNumber.Attributes.Append(attribute);
                rootNode.AppendChild(shiftTypePhoneNumber);

                attribute = xmlDocument.CreateAttribute("PhoneNumber");
                attribute.Value = findNumbers.PhoneNumber.ToString();
                shiftTypePhoneNumber.Attributes.Append(attribute);
                rootNode.AppendChild(shiftTypePhoneNumber);

                attribute = xmlDocument.CreateAttribute("CreatedBy");
                attribute.Value = findNumbers.CreatedBy.ToString();
                shiftTypePhoneNumber.Attributes.Append(attribute);
                rootNode.AppendChild(shiftTypePhoneNumber);
            }

            return xmlDocument.OuterXml;
        }
        #endregion
    }
}