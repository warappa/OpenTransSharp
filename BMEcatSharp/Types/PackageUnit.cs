﻿using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    public enum PackageUnit
    {
        [XmlEnum("04")] PU_04,
        [XmlEnum("05")] PU_05,
        [XmlEnum("08")] PU_08,
        [XmlEnum("10")] PU_10,
        [XmlEnum("11")] PU_11,
        [XmlEnum("13")] PU_13,
        [XmlEnum("14")] PU_14,
        [XmlEnum("15")] PU_15,
        [XmlEnum("16")] PU_16,
        [XmlEnum("17")] PU_17,
        [XmlEnum("18")] PU_18,
        [XmlEnum("19")] PU_19,
        [XmlEnum("1A")] PU_1A,
        [XmlEnum("1B")] PU_1B,
        [XmlEnum("1C")] PU_1C,
        [XmlEnum("1D")] PU_1D,
        [XmlEnum("1E")] PU_1E,
        [XmlEnum("1F")] PU_1F,
        [XmlEnum("1G")] PU_1G,
        [XmlEnum("1H")] PU_1H,
        [XmlEnum("1I")] PU_1I,
        [XmlEnum("1J")] PU_1J,
        [XmlEnum("1K")] PU_1K,
        [XmlEnum("1L")] PU_1L,
        [XmlEnum("1M")] PU_1M,
        [XmlEnum("1X")] PU_1X,
        [XmlEnum("20")] PU_20,
        [XmlEnum("21")] PU_21,
        [XmlEnum("22")] PU_22,
        [XmlEnum("23")] PU_23,
        [XmlEnum("24")] PU_24,
        [XmlEnum("25")] PU_25,
        [XmlEnum("26")] PU_26,
        [XmlEnum("27")] PU_27,
        [XmlEnum("28")] PU_28,
        [XmlEnum("29")] PU_29,
        [XmlEnum("2A")] PU_2A,
        [XmlEnum("2B")] PU_2B,
        [XmlEnum("2C")] PU_2C,
        [XmlEnum("2I")] PU_2I,
        [XmlEnum("2J")] PU_2J,
        [XmlEnum("2K")] PU_2K,
        [XmlEnum("2L")] PU_2L,
        [XmlEnum("2M")] PU_2M,
        [XmlEnum("2N")] PU_2N,
        [XmlEnum("2P")] PU_2P,
        [XmlEnum("2Q")] PU_2Q,
        [XmlEnum("2R")] PU_2R,
        [XmlEnum("2U")] PU_2U,
        [XmlEnum("2V")] PU_2V,
        [XmlEnum("2W")] PU_2W,
        [XmlEnum("2X")] PU_2X,
        [XmlEnum("2Y")] PU_2Y,
        [XmlEnum("2Z")] PU_2Z,
        [XmlEnum("30")] PU_30,
        [XmlEnum("31")] PU_31,
        [XmlEnum("32")] PU_32,
        [XmlEnum("33")] PU_33,
        [XmlEnum("34")] PU_34,
        [XmlEnum("35")] PU_35,
        [XmlEnum("36")] PU_36,
        [XmlEnum("37")] PU_37,
        [XmlEnum("38")] PU_38,
        [XmlEnum("3B")] PU_3B,
        [XmlEnum("3C")] PU_3C,
        [XmlEnum("3E")] PU_3E,
        [XmlEnum("3G")] PU_3G,
        [XmlEnum("3H")] PU_3H,
        [XmlEnum("3I")] PU_3I,
        [XmlEnum("40")] PU_40,
        [XmlEnum("41")] PU_41,
        [XmlEnum("43")] PU_43,
        [XmlEnum("44")] PU_44,
        [XmlEnum("45")] PU_45,
        [XmlEnum("46")] PU_46,
        [XmlEnum("47")] PU_47,
        [XmlEnum("48")] PU_48,
        [XmlEnum("4A")] PU_4A,
        [XmlEnum("4B")] PU_4B,
        [XmlEnum("4C")] PU_4C,
        [XmlEnum("4E")] PU_4E,
        [XmlEnum("4G")] PU_4G,
        [XmlEnum("4H")] PU_4H,
        [XmlEnum("4K")] PU_4K,
        [XmlEnum("4L")] PU_4L,
        [XmlEnum("4M")] PU_4M,
        [XmlEnum("4N")] PU_4N,
        [XmlEnum("4O")] PU_4O,
        [XmlEnum("4P")] PU_4P,
        [XmlEnum("4Q")] PU_4Q,
        [XmlEnum("4R")] PU_4R,
        [XmlEnum("4T")] PU_4T,
        [XmlEnum("4U")] PU_4U,
        [XmlEnum("4W")] PU_4W,
        [XmlEnum("4X")] PU_4X,
        [XmlEnum("53")] PU_53,
        [XmlEnum("54")] PU_54,
        [XmlEnum("56")] PU_56,
        [XmlEnum("57")] PU_57,
        [XmlEnum("58")] PU_58,
        [XmlEnum("59")] PU_59,
        [XmlEnum("5A")] PU_5A,
        [XmlEnum("5B")] PU_5B,
        [XmlEnum("5C")] PU_5C,
        [XmlEnum("5E")] PU_5E,
        [XmlEnum("5F")] PU_5F,
        [XmlEnum("5G")] PU_5G,
        [XmlEnum("5H")] PU_5H,
        [XmlEnum("5I")] PU_5I,
        [XmlEnum("5J")] PU_5J,
        [XmlEnum("5K")] PU_5K,
        [XmlEnum("5P")] PU_5P,
        [XmlEnum("5Q")] PU_5Q,
        [XmlEnum("60")] PU_60,
        [XmlEnum("61")] PU_61,
        [XmlEnum("62")] PU_62,
        [XmlEnum("63")] PU_63,
        [XmlEnum("64")] PU_64,
        [XmlEnum("66")] PU_66,
        [XmlEnum("69")] PU_69,
        [XmlEnum("71")] PU_71,
        [XmlEnum("72")] PU_72,
        [XmlEnum("73")] PU_73,
        [XmlEnum("74")] PU_74,
        [XmlEnum("76")] PU_76,
        [XmlEnum("77")] PU_77,
        [XmlEnum("78")] PU_78,
        [XmlEnum("80")] PU_80,
        [XmlEnum("81")] PU_81,
        [XmlEnum("84")] PU_84,
        [XmlEnum("85")] PU_85,
        [XmlEnum("87")] PU_87,
        [XmlEnum("89")] PU_89,
        [XmlEnum("90")] PU_90,
        [XmlEnum("91")] PU_91,
        [XmlEnum("92")] PU_92,
        [XmlEnum("93")] PU_93,
        [XmlEnum("94")] PU_94,
        [XmlEnum("95")] PU_95,
        [XmlEnum("96")] PU_96,
        [XmlEnum("97")] PU_97,
        [XmlEnum("98")] PU_98,
        [XmlEnum("A1")] A1,
        [XmlEnum("A10")] A10,
        [XmlEnum("A11")] A11,
        [XmlEnum("A12")] A12,
        [XmlEnum("A13")] A13,
        [XmlEnum("A14")] A14,
        [XmlEnum("A15")] A15,
        [XmlEnum("A16")] A16,
        [XmlEnum("A17")] A17,
        [XmlEnum("A18")] A18,
        [XmlEnum("A19")] A19,
        [XmlEnum("A2")] A2,
        [XmlEnum("A20")] A20,
        [XmlEnum("A21")] A21,
        [XmlEnum("A22")] A22,
        [XmlEnum("A23")] A23,
        [XmlEnum("A24")] A24,
        [XmlEnum("A25")] A25,
        [XmlEnum("A26")] A26,
        [XmlEnum("A27")] A27,
        [XmlEnum("A28")] A28,
        [XmlEnum("A29")] A29,
        [XmlEnum("A3")] A3,
        [XmlEnum("A30")] A30,
        [XmlEnum("A31")] A31,
        [XmlEnum("A32")] A32,
        [XmlEnum("A33")] A33,
        [XmlEnum("A34")] A34,
        [XmlEnum("A35")] A35,
        [XmlEnum("A36")] A36,
        [XmlEnum("A37")] A37,
        [XmlEnum("A38")] A38,
        [XmlEnum("A39")] A39,
        [XmlEnum("A4")] A4,
        [XmlEnum("A40")] A40,
        [XmlEnum("A41")] A41,
        [XmlEnum("A42")] A42,
        [XmlEnum("A43")] A43,
        [XmlEnum("A44")] A44,
        [XmlEnum("A45")] A45,
        [XmlEnum("A47")] A47,
        [XmlEnum("A48")] A48,
        [XmlEnum("A49")] A49,
        [XmlEnum("A5")] A5,
        [XmlEnum("A50")] A50,
        [XmlEnum("A51")] A51,
        [XmlEnum("A52")] A52,
        [XmlEnum("A53")] A53,
        [XmlEnum("A54")] A54,
        [XmlEnum("A55")] A55,
        [XmlEnum("A56")] A56,
        [XmlEnum("A57")] A57,
        [XmlEnum("A58")] A58,
        [XmlEnum("A6")] A6,
        [XmlEnum("A60")] A60,
        [XmlEnum("A61")] A61,
        [XmlEnum("A62")] A62,
        [XmlEnum("A63")] A63,
        [XmlEnum("A64")] A64,
        [XmlEnum("A65")] A65,
        [XmlEnum("A66")] A66,
        [XmlEnum("A67")] A67,
        [XmlEnum("A68")] A68,
        [XmlEnum("A69")] A69,
        [XmlEnum("A7")] A7,
        [XmlEnum("A70")] A70,
        [XmlEnum("A71")] A71,
        [XmlEnum("A73")] A73,
        [XmlEnum("A74")] A74,
        [XmlEnum("A75")] A75,
        [XmlEnum("A76")] A76,
        [XmlEnum("A77")] A77,
        [XmlEnum("A78")] A78,
        [XmlEnum("A79")] A79,
        [XmlEnum("A8")] A8,
        [XmlEnum("A80")] A80,
        [XmlEnum("A81")] A81,
        [XmlEnum("A82")] A82,
        [XmlEnum("A83")] A83,
        [XmlEnum("A84")] A84,
        [XmlEnum("A85")] A85,
        [XmlEnum("A86")] A86,
        [XmlEnum("A87")] A87,
        [XmlEnum("A88")] A88,
        [XmlEnum("A89")] A89,
        [XmlEnum("A9")] A9,
        [XmlEnum("A90")] A90,
        [XmlEnum("A91")] A91,
        [XmlEnum("A93")] A93,
        [XmlEnum("A94")] A94,
        [XmlEnum("A95")] A95,
        [XmlEnum("A96")] A96,
        [XmlEnum("A97")] A97,
        [XmlEnum("A98")] A98,
        [XmlEnum("AA")] AA,
        [XmlEnum("AB")] AB,
        [XmlEnum("ACR")] ACR,
        [XmlEnum("AD")] AD,
        [XmlEnum("AE")] AE,
        [XmlEnum("AH")] AH,
        [XmlEnum("AI")] AI,
        [XmlEnum("AJ")] AJ,
        [XmlEnum("AK")] AK,
        [XmlEnum("AL")] AL,
        [XmlEnum("AM")] AM,
        [XmlEnum("AMH")] AMH,
        [XmlEnum("AMP")] AMP,
        [XmlEnum("ANN")] ANN,
        [XmlEnum("AP")] AP,
        [XmlEnum("APZ")] APZ,
        [XmlEnum("AQ")] AQ,
        [XmlEnum("AR")] AR,
        [XmlEnum("ARE")] ARE,
        [XmlEnum("AS")] AS,
        [XmlEnum("ASM")] ASM,
        [XmlEnum("ASU")] ASU,
        [XmlEnum("ATM")] ATM,
        [XmlEnum("ATT")] ATT,
        [XmlEnum("AV")] AV,
        [XmlEnum("AW")] AW,
        [XmlEnum("AY")] AY,
        [XmlEnum("AZ")] AZ,
        [XmlEnum("B0")] B0,
        [XmlEnum("B1")] B1,
        [XmlEnum("B11")] B11,
        [XmlEnum("B12")] B12,
        [XmlEnum("B13")] B13,
        [XmlEnum("B14")] B14,
        [XmlEnum("B15")] B15,
        [XmlEnum("B16")] B16,
        [XmlEnum("B18")] B18,
        [XmlEnum("B2")] B2,
        [XmlEnum("B20")] B20,
        [XmlEnum("B21")] B21,
        [XmlEnum("B22")] B22,
        [XmlEnum("B23")] B23,
        [XmlEnum("B24")] B24,
        [XmlEnum("B25")] B25,
        [XmlEnum("B26")] B26,
        [XmlEnum("B27")] B27,
        [XmlEnum("B28")] B28,
        [XmlEnum("B29")] B29,
        [XmlEnum("B3")] B3,
        [XmlEnum("B31")] B31,
        [XmlEnum("B32")] B32,
        [XmlEnum("B33")] B33,
        [XmlEnum("B34")] B34,
        [XmlEnum("B35")] B35,
        [XmlEnum("B36")] B36,
        [XmlEnum("B37")] B37,
        [XmlEnum("B38")] B38,
        [XmlEnum("B39")] B39,
        [XmlEnum("B4")] B4,
        [XmlEnum("B40")] B40,
        [XmlEnum("B41")] B41,
        [XmlEnum("B42")] B42,
        [XmlEnum("B43")] B43,
        [XmlEnum("B44")] B44,
        [XmlEnum("B45")] B45,
        [XmlEnum("B46")] B46,
        [XmlEnum("B47")] B47,
        [XmlEnum("B48")] B48,
        [XmlEnum("B49")] B49,
        [XmlEnum("B5")] B5,
        [XmlEnum("B50")] B50,
        [XmlEnum("B51")] B51,
        [XmlEnum("B52")] B52,
        [XmlEnum("B53")] B53,
        [XmlEnum("B54")] B54,
        [XmlEnum("B55")] B55,
        [XmlEnum("B56")] B56,
        [XmlEnum("B57")] B57,
        [XmlEnum("B58")] B58,
        [XmlEnum("B59")] B59,
        [XmlEnum("B6")] B6,
        [XmlEnum("B60")] B60,
        [XmlEnum("B61")] B61,
        [XmlEnum("B62")] B62,
        [XmlEnum("B63")] B63,
        [XmlEnum("B64")] B64,
        [XmlEnum("B65")] B65,
        [XmlEnum("B66")] B66,
        [XmlEnum("B67")] B67,
        [XmlEnum("B69")] B69,
        [XmlEnum("B7")] B7,
        [XmlEnum("B70")] B70,
        [XmlEnum("B71")] B71,
        [XmlEnum("B72")] B72,
        [XmlEnum("B73")] B73,
        [XmlEnum("B74")] B74,
        [XmlEnum("B75")] B75,
        [XmlEnum("B76")] B76,
        [XmlEnum("B77")] B77,
        [XmlEnum("B78")] B78,
        [XmlEnum("B79")] B79,
        [XmlEnum("B8")] B8,
        [XmlEnum("B81")] B81,
        [XmlEnum("B83")] B83,
        [XmlEnum("B84")] B84,
        [XmlEnum("B85")] B85,
        [XmlEnum("B86")] B86,
        [XmlEnum("B87")] B87,
        [XmlEnum("B88")] B88,
        [XmlEnum("B89")] B89,
        [XmlEnum("B9")] B9,
        [XmlEnum("B90")] B90,
        [XmlEnum("B91")] B91,
        [XmlEnum("B92")] B92,
        [XmlEnum("B93")] B93,
        [XmlEnum("B94")] B94,
        [XmlEnum("B95")] B95,
        [XmlEnum("B96")] B96,
        [XmlEnum("B97")] B97,
        [XmlEnum("B98")] B98,
        [XmlEnum("B99")] B99,
        [XmlEnum("BAR")] BAR,
        [XmlEnum("BB")] BB,
        [XmlEnum("BD")] BD,
        [XmlEnum("BE")] BE,
        [XmlEnum("BFT")] BFT,
        [XmlEnum("BG")] BG,
        [XmlEnum("BH")] BH,
        [XmlEnum("BHP")] BHP,
        [XmlEnum("BIL")] BIL,
        [XmlEnum("BJ")] BJ,
        [XmlEnum("BK")] BK,
        [XmlEnum("BL")] BL,
        [XmlEnum("BLD")] BLD,
        [XmlEnum("BLL")] BLL,
        [XmlEnum("BO")] BO,
        [XmlEnum("BP")] BP,
        [XmlEnum("BQL")] BQL,
        [XmlEnum("BR")] BR,
        [XmlEnum("BT")] BT,
        [XmlEnum("BTU")] BTU,
        [XmlEnum("BUA")] BUA,
        [XmlEnum("BUI")] BUI,
        [XmlEnum("BW")] BW,
        [XmlEnum("BX")] BX,
        [XmlEnum("BZ")] BZ,
        [XmlEnum("C0")] C0,
        [XmlEnum("C1")] C1,
        [XmlEnum("C10")] C10,
        [XmlEnum("C11")] C11,
        [XmlEnum("C12")] C12,
        [XmlEnum("C13")] C13,
        [XmlEnum("C14")] C14,
        [XmlEnum("C15")] C15,
        [XmlEnum("C16")] C16,
        [XmlEnum("C17")] C17,
        [XmlEnum("C18")] C18,
        [XmlEnum("C19")] C19,
        [XmlEnum("C2")] C2,
        [XmlEnum("C20")] C20,
        [XmlEnum("C22")] C22,
        [XmlEnum("C23")] C23,
        [XmlEnum("C24")] C24,
        [XmlEnum("C25")] C25,
        [XmlEnum("C26")] C26,
        [XmlEnum("C27")] C27,
        [XmlEnum("C28")] C28,
        [XmlEnum("C29")] C29,
        [XmlEnum("C3")] C3,
        [XmlEnum("C30")] C30,
        [XmlEnum("C31")] C31,
        [XmlEnum("C32")] C32,
        [XmlEnum("C33")] C33,
        [XmlEnum("C34")] C34,
        [XmlEnum("C35")] C35,
        [XmlEnum("C36")] C36,
        [XmlEnum("C38")] C38,
        [XmlEnum("C39")] C39,
        [XmlEnum("C4")] C4,
        [XmlEnum("C40")] C40,
        [XmlEnum("C41")] C41,
        [XmlEnum("C42")] C42,
        [XmlEnum("C43")] C43,
        [XmlEnum("C44")] C44,
        [XmlEnum("C45")] C45,
        [XmlEnum("C46")] C46,
        [XmlEnum("C47")] C47,
        [XmlEnum("C48")] C48,
        [XmlEnum("C49")] C49,
        [XmlEnum("C5")] C5,
        [XmlEnum("C50")] C50,
        [XmlEnum("C51")] C51,
        [XmlEnum("C52")] C52,
        [XmlEnum("C53")] C53,
        [XmlEnum("C54")] C54,
        [XmlEnum("C55")] C55,
        [XmlEnum("C56")] C56,
        [XmlEnum("C57")] C57,
        [XmlEnum("C58")] C58,
        [XmlEnum("C59")] C59,
        [XmlEnum("C6")] C6,
        [XmlEnum("C60")] C60,
        [XmlEnum("C61")] C61,
        [XmlEnum("C62")] C62,
        [XmlEnum("C63")] C63,
        [XmlEnum("C64")] C64,
        [XmlEnum("C65")] C65,
        [XmlEnum("C66")] C66,
        [XmlEnum("C67")] C67,
        [XmlEnum("C68")] C68,
        [XmlEnum("C69")] C69,
        [XmlEnum("C7")] C7,
        [XmlEnum("C70")] C70,
        [XmlEnum("C71")] C71,
        [XmlEnum("C72")] C72,
        [XmlEnum("C73")] C73,
        [XmlEnum("C75")] C75,
        [XmlEnum("C76")] C76,
        [XmlEnum("C77")] C77,
        [XmlEnum("C78")] C78,
        [XmlEnum("C8")] C8,
        [XmlEnum("C80")] C80,
        [XmlEnum("C81")] C81,
        [XmlEnum("C82")] C82,
        [XmlEnum("C83")] C83,
        [XmlEnum("C84")] C84,
        [XmlEnum("C85")] C85,
        [XmlEnum("C86")] C86,
        [XmlEnum("C87")] C87,
        [XmlEnum("C88")] C88,
        [XmlEnum("C89")] C89,
        [XmlEnum("C9")] C9,
        [XmlEnum("C90")] C90,
        [XmlEnum("C91")] C91,
        [XmlEnum("C92")] C92,
        [XmlEnum("C93")] C93,
        [XmlEnum("C94")] C94,
        [XmlEnum("C95")] C95,
        [XmlEnum("C96")] C96,
        [XmlEnum("C97")] C97,
        [XmlEnum("C98")] C98,
        [XmlEnum("C99")] C99,
        [XmlEnum("CA")] CA,
        [XmlEnum("CCT")] CCT,
        [XmlEnum("CDL")] CDL,
        [XmlEnum("CEL")] CEL,
        [XmlEnum("CEN")] CEN,
        [XmlEnum("CG")] CG,
        [XmlEnum("CGM")] CGM,
        [XmlEnum("CH")] CH,
        [XmlEnum("CJ")] CJ,
        [XmlEnum("CK")] CK,
        [XmlEnum("CKG")] CKG,
        [XmlEnum("CL")] CL,
        [XmlEnum("CLF")] CLF,
        [XmlEnum("CLT")] CLT,
        [XmlEnum("CMK")] CMK,
        [XmlEnum("CMQ")] CMQ,
        [XmlEnum("CMT")] CMT,
        [XmlEnum("CNP")] CNP,
        [XmlEnum("CNT")] CNT,
        [XmlEnum("CO")] CO,
        [XmlEnum("COU")] COU,
        [XmlEnum("CQ")] CQ,
        [XmlEnum("CR")] CR,
        [XmlEnum("CS")] CS,
        [XmlEnum("CT")] CT,
        [XmlEnum("CTM")] CTM,
        [XmlEnum("CU")] CU,
        [XmlEnum("CUR")] CUR,
        [XmlEnum("CV")] CV,
        [XmlEnum("CWA")] CWA,
        [XmlEnum("CWI")] CWI,
        [XmlEnum("CY")] CY,
        [XmlEnum("CZ")] CZ,
        [XmlEnum("D1")] D1,
        [XmlEnum("D10")] D10,
        [XmlEnum("D12")] D12,
        [XmlEnum("D13")] D13,
        [XmlEnum("D14")] D14,
        [XmlEnum("D15")] D15,
        [XmlEnum("D16")] D16,
        [XmlEnum("D17")] D17,
        [XmlEnum("D18")] D18,
        [XmlEnum("D19")] D19,
        [XmlEnum("D2")] D2,
        [XmlEnum("D20")] D20,
        [XmlEnum("D21")] D21,
        [XmlEnum("D22")] D22,
        [XmlEnum("D23")] D23,
        [XmlEnum("D24")] D24,
        [XmlEnum("D25")] D25,
        [XmlEnum("D26")] D26,
        [XmlEnum("D27")] D27,
        [XmlEnum("D28")] D28,
        [XmlEnum("D29")] D29,
        [XmlEnum("D30")] D30,
        [XmlEnum("D31")] D31,
        [XmlEnum("D32")] D32,
        [XmlEnum("D33")] D33,
        [XmlEnum("D34")] D34,
        [XmlEnum("D35")] D35,
        [XmlEnum("D37")] D37,
        [XmlEnum("D38")] D38,
        [XmlEnum("D39")] D39,
        [XmlEnum("D40")] D40,
        [XmlEnum("D41")] D41,
        [XmlEnum("D42")] D42,
        [XmlEnum("D43")] D43,
        [XmlEnum("D44")] D44,
        [XmlEnum("D45")] D45,
        [XmlEnum("D46")] D46,
        [XmlEnum("D47")] D47,
        [XmlEnum("D48")] D48,
        [XmlEnum("D49")] D49,
        [XmlEnum("D5")] D5,
        [XmlEnum("D50")] D50,
        [XmlEnum("D51")] D51,
        [XmlEnum("D52")] D52,
        [XmlEnum("D53")] D53,
        [XmlEnum("D54")] D54,
        [XmlEnum("D55")] D55,
        [XmlEnum("D56")] D56,
        [XmlEnum("D57")] D57,
        [XmlEnum("D58")] D58,
        [XmlEnum("D59")] D59,
        [XmlEnum("D6")] D6,
        [XmlEnum("D60")] D60,
        [XmlEnum("D61")] D61,
        [XmlEnum("D62")] D62,
        [XmlEnum("D63")] D63,
        [XmlEnum("D64")] D64,
        [XmlEnum("D65")] D65,
        [XmlEnum("D66")] D66,
        [XmlEnum("D67")] D67,
        [XmlEnum("D69")] D69,
        [XmlEnum("D7")] D7,
        [XmlEnum("D70")] D70,
        [XmlEnum("D71")] D71,
        [XmlEnum("D72")] D72,
        [XmlEnum("D73")] D73,
        [XmlEnum("D74")] D74,
        [XmlEnum("D75")] D75,
        [XmlEnum("D76")] D76,
        [XmlEnum("D77")] D77,
        [XmlEnum("D79")] D79,
        [XmlEnum("D8")] D8,
        [XmlEnum("D80")] D80,
        [XmlEnum("D81")] D81,
        [XmlEnum("D82")] D82,
        [XmlEnum("D83")] D83,
        [XmlEnum("D85")] D85,
        [XmlEnum("D86")] D86,
        [XmlEnum("D87")] D87,
        [XmlEnum("D88")] D88,
        [XmlEnum("D89")] D89,
        [XmlEnum("D9")] D9,
        [XmlEnum("D90")] D90,
        [XmlEnum("D91")] D91,
        [XmlEnum("D92")] D92,
        [XmlEnum("D93")] D93,
        [XmlEnum("D94")] D94,
        [XmlEnum("D95")] D95,
        [XmlEnum("D96")] D96,
        [XmlEnum("D97")] D97,
        [XmlEnum("D98")] D98,
        [XmlEnum("D99")] D99,
        [XmlEnum("DAA")] DAA,
        [XmlEnum("DAD")] DAD,
        [XmlEnum("DAY")] DAY,
        [XmlEnum("DB")] DB,
        [XmlEnum("DC")] DC,
        [XmlEnum("DD")] DD,
        [XmlEnum("DE")] DE,
        [XmlEnum("DEC")] DEC,
        [XmlEnum("DG")] DG,
        [XmlEnum("DI")] DI,
        [XmlEnum("DJ")] DJ,
        [XmlEnum("DLT")] DLT,
        [XmlEnum("DMK")] DMK,
        [XmlEnum("DMQ")] DMQ,
        [XmlEnum("DMT")] DMT,
        [XmlEnum("DN")] DN,
        [XmlEnum("DPC")] DPC,
        [XmlEnum("DPR")] DPR,
        [XmlEnum("DPT")] DPT,
        [XmlEnum("DQ")] DQ,
        [XmlEnum("DR")] DR,
        [XmlEnum("DRA")] DRA,
        [XmlEnum("DRI")] DRI,
        [XmlEnum("DRL")] DRL,
        [XmlEnum("DRM")] DRM,
        [XmlEnum("DS")] DS,
        [XmlEnum("DT")] DT,
        [XmlEnum("DTN")] DTN,
        [XmlEnum("DU")] DU,
        [XmlEnum("DWT")] DWT,
        [XmlEnum("DX")] DX,
        [XmlEnum("DY")] DY,
        [XmlEnum("DZN")] DZN,
        [XmlEnum("DZP")] DZP,
        [XmlEnum("E10")] E10,
        [XmlEnum("E11")] E11,
        [XmlEnum("E2")] E2,
        [XmlEnum("E3")] E3,
        [XmlEnum("E4")] E4,
        [XmlEnum("E5")] E5,
        [XmlEnum("EA")] EA,
        [XmlEnum("EB")] EB,
        [XmlEnum("EC")] EC,
        [XmlEnum("EP")] EP,
        [XmlEnum("EQ")] EQ,
        [XmlEnum("EV")] EV,
        [XmlEnum("F1")] F1,
        [XmlEnum("F9")] F9,
        [XmlEnum("FAH")] FAH,
        [XmlEnum("FAR")] FAR,
        [XmlEnum("FB")] FB,
        [XmlEnum("FC")] FC,
        [XmlEnum("FD")] FD,
        [XmlEnum("FE")] FE,
        [XmlEnum("FF")] FF,
        [XmlEnum("FG")] FG,
        [XmlEnum("FH")] FH,
        [XmlEnum("FL")] FL,
        [XmlEnum("FM")] FM,
        [XmlEnum("FOT")] FOT,
        [XmlEnum("FP")] FP,
        [XmlEnum("FR")] FR,
        [XmlEnum("FS")] FS,
        [XmlEnum("FTK")] FTK,
        [XmlEnum("FTQ")] FTQ,
        [XmlEnum("G2")] G2,
        [XmlEnum("G3")] G3,
        [XmlEnum("G7")] G7,
        [XmlEnum("GB")] GB,
        [XmlEnum("GBQ")] GBQ,
        [XmlEnum("GC")] GC,
        [XmlEnum("GD")] GD,
        [XmlEnum("GE")] GE,
        [XmlEnum("GF")] GF,
        [XmlEnum("GFI")] GFI,
        [XmlEnum("GGR")] GGR,
        [XmlEnum("GH")] GH,
        [XmlEnum("GIA")] GIA,
        [XmlEnum("GII")] GII,
        [XmlEnum("GJ")] GJ,
        [XmlEnum("GK")] GK,
        [XmlEnum("GL")] GL,
        [XmlEnum("GLD")] GLD,
        [XmlEnum("GLI")] GLI,
        [XmlEnum("GLL")] GLL,
        [XmlEnum("GM")] GM,
        [XmlEnum("GN")] GN,
        [XmlEnum("GO")] GO,
        [XmlEnum("GP")] GP,
        [XmlEnum("GQ")] GQ,
        [XmlEnum("GRM")] GRM,
        [XmlEnum("GRN")] GRN,
        [XmlEnum("GRO")] GRO,
        [XmlEnum("GRT")] GRT,
        [XmlEnum("GT")] GT,
        [XmlEnum("GV")] GV,
        [XmlEnum("GW")] GW,
        [XmlEnum("GWH")] GWH,
        [XmlEnum("GY")] GY,
        [XmlEnum("GZ")] GZ,
        [XmlEnum("H1")] H1,
        [XmlEnum("H2")] H2,
        [XmlEnum("HA")] HA,
        [XmlEnum("HAR")] HAR,
        [XmlEnum("HBA")] HBA,
        [XmlEnum("HBX")] HBX,
        [XmlEnum("HC")] HC,
        [XmlEnum("HD")] HD,
        [XmlEnum("HE")] HE,
        [XmlEnum("HF")] HF,
        [XmlEnum("HGM")] HGM,
        [XmlEnum("HH")] HH,
        [XmlEnum("HI")] HI,
        [XmlEnum("HIU")] HIU,
        [XmlEnum("HJ")] HJ,
        [XmlEnum("HK")] HK,
        [XmlEnum("HL")] HL,
        [XmlEnum("HLT")] HLT,
        [XmlEnum("HM")] HM,
        [XmlEnum("HMQ")] HMQ,
        [XmlEnum("HMT")] HMT,
        [XmlEnum("HN")] HN,
        [XmlEnum("HO")] HO,
        [XmlEnum("HP")] HP,
        [XmlEnum("HPA")] HPA,
        [XmlEnum("HS")] HS,
        [XmlEnum("HT")] HT,
        [XmlEnum("HTZ")] HTZ,
        [XmlEnum("HUR")] HUR,
        [XmlEnum("HY")] HY,
        [XmlEnum("IA")] IA,
        [XmlEnum("IC")] IC,
        [XmlEnum("IE")] IE,
        [XmlEnum("IF")] IF,
        [XmlEnum("II")] II,
        [XmlEnum("IL")] IL,
        [XmlEnum("IM")] IM,
        [XmlEnum("INH")] INH,
        [XmlEnum("INK")] INK,
        [XmlEnum("INQ")] INQ,
        [XmlEnum("IP")] IP,
        [XmlEnum("IT")] IT,
        [XmlEnum("IU")] IU,
        [XmlEnum("IV")] IV,
        [XmlEnum("J2")] J2,
        [XmlEnum("JB")] JB,
        [XmlEnum("JE")] JE,
        [XmlEnum("JG")] JG,
        [XmlEnum("JK")] JK,
        [XmlEnum("JM")] JM,
        [XmlEnum("JO")] JO,
        [XmlEnum("JOU")] JOU,
        [XmlEnum("JR")] JR,
        [XmlEnum("K1")] K1,
        [XmlEnum("K2")] K2,
        [XmlEnum("K3")] K3,
        [XmlEnum("K5")] K5,
        [XmlEnum("K6")] K6,
        [XmlEnum("KA")] KA,
        [XmlEnum("KB")] KB,
        [XmlEnum("KBA")] KBA,
        [XmlEnum("KD")] KD,
        [XmlEnum("KEL")] KEL,
        [XmlEnum("KF")] KF,
        [XmlEnum("KG")] KG,
        [XmlEnum("KGM")] KGM,
        [XmlEnum("KGS")] KGS,
        [XmlEnum("KHZ")] KHZ,
        [XmlEnum("KI")] KI,
        [XmlEnum("KJ")] KJ,
        [XmlEnum("KJO")] KJO,
        [XmlEnum("KL")] KL,
        [XmlEnum("KMH")] KMH,
        [XmlEnum("KMK")] KMK,
        [XmlEnum("KMQ")] KMQ,
        [XmlEnum("KNI")] KNI,
        [XmlEnum("KNS")] KNS,
        [XmlEnum("KNT")] KNT,
        [XmlEnum("KO")] KO,
        [XmlEnum("KPA")] KPA,
        [XmlEnum("KPH")] KPH,
        [XmlEnum("KPO")] KPO,
        [XmlEnum("KPP")] KPP,
        [XmlEnum("KR")] KR,
        [XmlEnum("KS")] KS,
        [XmlEnum("KSD")] KSD,
        [XmlEnum("KSH")] KSH,
        [XmlEnum("KT")] KT,
        [XmlEnum("KTM")] KTM,
        [XmlEnum("KTN")] KTN,
        [XmlEnum("KUR")] KUR,
        [XmlEnum("KVA")] KVA,
        [XmlEnum("KVR")] KVR,
        [XmlEnum("KVT")] KVT,
        [XmlEnum("KW")] KW,
        [XmlEnum("KWH")] KWH,
        [XmlEnum("KWT")] KWT,
        [XmlEnum("KX")] KX,
        [XmlEnum("L2")] L2,
        [XmlEnum("LA")] LA,
        [XmlEnum("LBR")] LBR,
        [XmlEnum("LBT")] LBT,
        [XmlEnum("LC")] LC,
        [XmlEnum("LD")] LD,
        [XmlEnum("LE")] LE,
        [XmlEnum("LEF")] LEF,
        [XmlEnum("LF")] LF,
        [XmlEnum("LH")] LH,
        [XmlEnum("LI")] LI,
        [XmlEnum("LJ")] LJ,
        [XmlEnum("LK")] LK,
        [XmlEnum("LM")] LM,
        [XmlEnum("LN")] LN,
        [XmlEnum("LO")] LO,
        [XmlEnum("LP")] LP,
        [XmlEnum("LPA")] LPA,
        [XmlEnum("LR")] LR,
        [XmlEnum("LS")] LS,
        [XmlEnum("LTN")] LTN,
        [XmlEnum("LTR")] LTR,
        [XmlEnum("LUM")] LUM,
        [XmlEnum("LUX")] LUX,
        [XmlEnum("LX")] LX,
        [XmlEnum("LY")] LY,
        [XmlEnum("M0")] M0,
        [XmlEnum("M1")] M1,
        [XmlEnum("M4")] M4,
        [XmlEnum("M5")] M5,
        [XmlEnum("M7")] M7,
        [XmlEnum("M9")] M9,
        [XmlEnum("MA")] MA,
        [XmlEnum("MAL")] MAL,
        [XmlEnum("MAM")] MAM,
        [XmlEnum("MAW")] MAW,
        [XmlEnum("MBE")] MBE,
        [XmlEnum("MBF")] MBF,
        [XmlEnum("MBR")] MBR,
        [XmlEnum("MC")] MC,
        [XmlEnum("MCU")] MCU,
        [XmlEnum("MD")] MD,
        [XmlEnum("MF")] MF,
        [XmlEnum("MGM")] MGM,
        [XmlEnum("MHZ")] MHZ,
        [XmlEnum("MIK")] MIK,
        [XmlEnum("MIL")] MIL,
        [XmlEnum("MIN")] MIN,
        [XmlEnum("MIO")] MIO,
        [XmlEnum("MIU")] MIU,
        [XmlEnum("MK")] MK,
        [XmlEnum("MLD")] MLD,
        [XmlEnum("MLT")] MLT,
        [XmlEnum("MMK")] MMK,
        [XmlEnum("MMQ")] MMQ,
        [XmlEnum("MMT")] MMT,
        [XmlEnum("MON")] MON,
        [XmlEnum("MPA")] MPA,
        [XmlEnum("MQ")] MQ,
        [XmlEnum("MQH")] MQH,
        [XmlEnum("MQS")] MQS,
        [XmlEnum("MSK")] MSK,
        [XmlEnum("MT")] MT,
        [XmlEnum("MTK")] MTK,
        [XmlEnum("MTQ")] MTQ,
        [XmlEnum("MTR")] MTR,
        [XmlEnum("MTS")] MTS,
        [XmlEnum("MV")] MV,
        [XmlEnum("MVA")] MVA,
        [XmlEnum("MWH")] MWH,
        [XmlEnum("N1")] N1,
        [XmlEnum("N2")] N2,
        [XmlEnum("N3")] N3,
        [XmlEnum("NA")] NA,
        [XmlEnum("NAR")] NAR,
        [XmlEnum("NB")] NB,
        [XmlEnum("NBB")] NBB,
        [XmlEnum("NC")] NC,
        [XmlEnum("NCL")] NCL,
        [XmlEnum("ND")] ND,
        [XmlEnum("NE")] NE,
        [XmlEnum("NEW")] NEW,
        [XmlEnum("NF")] NF,
        [XmlEnum("NG")] NG,
        [XmlEnum("NH")] NH,
        [XmlEnum("NI")] NI,
        [XmlEnum("NIU")] NIU,
        [XmlEnum("NJ")] NJ,
        [XmlEnum("NL")] NL,
        [XmlEnum("NMI")] NMI,
        [XmlEnum("NMP")] NMP,
        [XmlEnum("NN")] NN,
        [XmlEnum("NPL")] NPL,
        [XmlEnum("NPR")] NPR,
        [XmlEnum("NPT")] NPT,
        [XmlEnum("NQ")] NQ,
        [XmlEnum("NR")] NR,
        [XmlEnum("NRL")] NRL,
        [XmlEnum("NT")] NT,
        [XmlEnum("NTT")] NTT,
        [XmlEnum("NU")] NU,
        [XmlEnum("NV")] NV,
        [XmlEnum("NX")] NX,
        [XmlEnum("NY")] NY,
        [XmlEnum("OA")] OA,
        [XmlEnum("OHM")] OHM,
        [XmlEnum("ON")] ON,
        [XmlEnum("ONZ")] ONZ,
        [XmlEnum("OP")] OP,
        [XmlEnum("OT")] OT,
        [XmlEnum("OZ")] OZ,
        [XmlEnum("OZA")] OZA,
        [XmlEnum("OZI")] OZI,
        [XmlEnum("P0")] P0,
        [XmlEnum("P1")] P1,
        [XmlEnum("P2")] P2,
        [XmlEnum("P3")] P3,
        [XmlEnum("P4")] P4,
        [XmlEnum("P5")] P5,
        [XmlEnum("P6")] P6,
        [XmlEnum("P7")] P7,
        [XmlEnum("P8")] P8,
        [XmlEnum("P9")] P9,
        [XmlEnum("PA")] PA,
        [XmlEnum("PAL")] PAL,
        [XmlEnum("PB")] PB,
        [XmlEnum("PD")] PD,
        [XmlEnum("PE")] PE,
        [XmlEnum("PF")] PF,
        [XmlEnum("PG")] PG,
        [XmlEnum("PGL")] PGL,
        [XmlEnum("PI")] PI,
        [XmlEnum("PK")] PK,
        [XmlEnum("PL")] PL,
        [XmlEnum("PM")] PM,
        [XmlEnum("PN")] PN,
        [XmlEnum("PO")] PO,
        [XmlEnum("PQ")] PQ,
        [XmlEnum("PR")] PR,
        [XmlEnum("PS")] PS,
        [XmlEnum("PT")] PT,
        [XmlEnum("PTD")] PTD,
        [XmlEnum("PTI")] PTI,
        [XmlEnum("PTL")] PTL,
        [XmlEnum("PU")] PU,
        [XmlEnum("PV")] PV,
        [XmlEnum("PW")] PW,
        [XmlEnum("PY")] PY,
        [XmlEnum("PZ")] PZ,
        [XmlEnum("Q3")] Q3,
        [XmlEnum("QA")] QA,
        [XmlEnum("QAN")] QAN,
        [XmlEnum("QB")] QB,
        [XmlEnum("QD")] QD,
        [XmlEnum("QH")] QH,
        [XmlEnum("QK")] QK,
        [XmlEnum("QR")] QR,
        [XmlEnum("QT")] QT,
        [XmlEnum("QTD")] QTD,
        [XmlEnum("QTI")] QTI,
        [XmlEnum("QTL")] QTL,
        [XmlEnum("QTR")] QTR,
        [XmlEnum("R1")] R1,
        [XmlEnum("R4")] R4,
        [XmlEnum("R9")] R9,
        [XmlEnum("RA")] RA,
        [XmlEnum("RD")] RD,
        [XmlEnum("RG")] RG,
        [XmlEnum("RH")] RH,
        [XmlEnum("RK")] RK,
        [XmlEnum("RL")] RL,
        [XmlEnum("RM")] RM,
        [XmlEnum("RN")] RN,
        [XmlEnum("RO")] RO,
        [XmlEnum("RP")] RP,
        [XmlEnum("RPM")] RPM,
        [XmlEnum("RPS")] RPS,
        [XmlEnum("RS")] RS,
        [XmlEnum("RT")] RT,
        [XmlEnum("RU")] RU,
        [XmlEnum("S3")] S3,
        [XmlEnum("S4")] S4,
        [XmlEnum("S5")] S5,
        [XmlEnum("S6")] S6,
        [XmlEnum("S7")] S7,
        [XmlEnum("S8")] S8,
        [XmlEnum("SA")] SA,
        [XmlEnum("SAN")] SAN,
        [XmlEnum("SCO")] SCO,
        [XmlEnum("SCR")] SCR,
        [XmlEnum("SD")] SD,
        [XmlEnum("SE")] SE,
        [XmlEnum("SEC")] SEC,
        [XmlEnum("SET")] SET,
        [XmlEnum("SG")] SG,
        [XmlEnum("SHT")] SHT,
        [XmlEnum("SIE")] SIE,
        [XmlEnum("SK")] SK,
        [XmlEnum("SL")] SL,
        [XmlEnum("SMI")] SMI,
        [XmlEnum("SN")] SN,
        [XmlEnum("SO")] SO,
        [XmlEnum("SP")] SP,
        [XmlEnum("SQ")] SQ,
        [XmlEnum("SR")] SR,
        [XmlEnum("SS")] SS,
        [XmlEnum("SST")] SST,
        [XmlEnum("ST")] ST,
        [XmlEnum("STI")] STI,
        [XmlEnum("STN")] STN,
        [XmlEnum("SV")] SV,
        [XmlEnum("SW")] SW,
        [XmlEnum("SX")] SX,
        [XmlEnum("T0")] T0,
        [XmlEnum("T1")] T1,
        [XmlEnum("T3")] T3,
        [XmlEnum("T4")] T4,
        [XmlEnum("T5")] T5,
        [XmlEnum("T6")] T6,
        [XmlEnum("T7")] T7,
        [XmlEnum("T8")] T8,
        [XmlEnum("TA")] TA,
        [XmlEnum("TAH")] TAH,
        [XmlEnum("TC")] TC,
        [XmlEnum("TD")] TD,
        [XmlEnum("TE")] TE,
        [XmlEnum("TF")] TF,
        [XmlEnum("TI")] TI,
        [XmlEnum("TJ")] TJ,
        [XmlEnum("TK")] TK,
        [XmlEnum("TL")] TL,
        [XmlEnum("TN")] TN,
        [XmlEnum("TNE")] TNE,
        [XmlEnum("TP")] TP,
        [XmlEnum("TPR")] TPR,
        [XmlEnum("TQ")] TQ,
        [XmlEnum("TQD")] TQD,
        [XmlEnum("TR")] TR,
        [XmlEnum("TRL")] TRL,
        [XmlEnum("TS")] TS,
        [XmlEnum("TSD")] TSD,
        [XmlEnum("TSH")] TSH,
        [XmlEnum("TT")] TT,
        [XmlEnum("TU")] TU,
        [XmlEnum("TV")] TV,
        [XmlEnum("TW")] TW,
        [XmlEnum("TY")] TY,
        [XmlEnum("U1")] U1,
        [XmlEnum("U2")] U2,
        [XmlEnum("UA")] UA,
        [XmlEnum("UB")] UB,
        [XmlEnum("UC")] UC,
        [XmlEnum("UD")] UD,
        [XmlEnum("UE")] UE,
        [XmlEnum("UF")] UF,
        [XmlEnum("UH")] UH,
        [XmlEnum("UM")] UM,
        [XmlEnum("VA")] VA,
        [XmlEnum("VI")] VI,
        [XmlEnum("VLT")] VLT,
        [XmlEnum("VQ")] VQ,
        [XmlEnum("VS")] VS,
        [XmlEnum("W2")] W2,
        [XmlEnum("W4")] W4,
        [XmlEnum("WA")] WA,
        [XmlEnum("WB")] WB,
        [XmlEnum("WCD")] WCD,
        [XmlEnum("WE")] WE,
        [XmlEnum("WEB")] WEB,
        [XmlEnum("WEE")] WEE,
        [XmlEnum("WG")] WG,
        [XmlEnum("WH")] WH,
        [XmlEnum("WHR")] WHR,
        [XmlEnum("WI")] WI,
        [XmlEnum("WM")] WM,
        [XmlEnum("WR")] WR,
        [XmlEnum("WSD")] WSD,
        [XmlEnum("WTT")] WTT,
        [XmlEnum("WW")] WW,
        [XmlEnum("X1")] X1,
        [XmlEnum("YDK")] YDK,
        [XmlEnum("YDQ")] YDQ,
        [XmlEnum("YL")] YL,
        [XmlEnum("YRD")] YRD,
        [XmlEnum("YT")] YT,
        [XmlEnum("Z1")] Z1,
        [XmlEnum("Z2")] Z2,
        [XmlEnum("Z3")] Z3,
        [XmlEnum("Z4")] Z4,
        [XmlEnum("Z5")] Z5,
        [XmlEnum("Z6")] Z6,
        [XmlEnum("Z8")] Z8,
        [XmlEnum("ZP")] ZP,
        [XmlEnum("ZZ")] ZZ,
    }
}
