﻿using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAutoUseThisAddressSettings
{
    public class GetAutoUseThisAddressSettingsQuery : IRequest<CommonResultResponseDto<AutoUseThisAddressResponseDto>>
    {
    }
}
