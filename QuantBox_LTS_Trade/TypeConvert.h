#pragma once

#include "../include/LTS/SecurityFtdcUserApiDataType.h"
#include "../include/LTS/SecurityFtdcUserApiStruct.h"
#include "../include/ApiStruct.h"


//PutCall TSecurityFtdcOptionsTypeType_2_PutCall(TSecurityFtdcOptionsTypeType In);

HedgeFlagType TSecurityFtdcHedgeFlagType_2_HedgeFlagType(TSecurityFtdcHedgeFlagType In);
TSecurityFtdcHedgeFlagType HedgeFlagType_2_TSecurityFtdcHedgeFlagType(HedgeFlagType In);

TSecurityFtdcOffsetFlagType OpenCloseType_2_TSecurityFtdcOffsetFlagType(OpenCloseType In);
OpenCloseType TSecurityFtdcOffsetFlagType_2_OpenCloseType(TSecurityFtdcOffsetFlagType In);

TSecurityFtdcDirectionType OrderSide_2_TSecurityFtdcDirectionType(OrderSide In);
OrderSide TSecurityFtdcDirectionType_2_OrderSide(TSecurityFtdcDirectionType In);

TSecurityFtdcOrderPriceTypeType OrderType_2_TSecurityFtdcOrderPriceTypeType(OrderType In);

OrderStatus CSecurityFtdcOrderField_2_OrderStatus(CSecurityFtdcOrderField* pIn);
OrderType CSecurityFtdcOrderField_2_OrderType(CSecurityFtdcOrderField* pIn);
TimeInForce CSecurityFtdcOrderField_2_TimeInForce(CSecurityFtdcOrderField* pIn);
ExecType CSecurityFtdcOrderField_2_ExecType(CSecurityFtdcOrderField* pIn);

InstrumentType CSecurityFtdcInstrumentField_2_InstrumentType(CSecurityFtdcInstrumentField* pIn);