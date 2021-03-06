using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTC_Help.Color
{
    public class ColorHelp
    {
        public string[] colorList()
        {
            string[] colorbox = { "#03A9F4", "#CA8EFF", "#C48888", "#81C0C0", "#FFE66F", "#FFAD86", "#96FED1", "#AAAAFF", "#FF5151", "#BEBEBE",
            "#CD5C5C", "#F08080", "#FA8072", "#E9967A", "#FFA07A", "#DC143C", "#FF0000", "#B22222", "#8B0000", "#FFC0CB", "#FFB6C1",
            "#FF69B4", "#FF1493", "#C71585", "#DB7093", "#FFA07A", "#FF7F50", "#FF6347", "#FF4500", "#FF8C00", "#FFA500", "#FFD700",
            "#FFFF00", "#FFFFE0", "#FFFACD", "#FAFAD2", "#FFEFD5", "#FFE4B5", "#FFDAB9", "#EEE8AA", "#F0E68C", "#BDB76B", "#E6E6FA",
            "#D8BFD8", "#DDA0DD", "#EE82EE", "#DA70D6", "#FF00FF", "#FF00FF", "#BA55D3", "#9370DB", "#663399", "#8A2BE2", "#9400D3",
            "#9932CC", "#8B008B", "#800080", "#4B0082", "#6A5ACD", "#483D8B", "#7B68EE", "#ADFF2F", "#7FFF00", "#7CFC00", "#00FF00",
            "#32CD32", "#98FB98", "#90EE90", "#00FA9A", "#00FF7F", "#3CB371", "#2E8B57", "#228B22", "#008000", "#006400", "#9ACD32",
            "#6B8E23", "#808000", "#556B2F", "#66CDAA", "#8FBC8B", "#20B2AA", "#008B8B", "#008080", "#00FFFF", "#00FFFF", "#E0FFFF",
            "#AFEEEE", "#7FFFD4", "#40E0D0", "#48D1CC", "#00CED1", "#5F9EA0", "#4682B4", "#B0C4DE", "#B0E0E6", "#ADD8E6", "#87CEEB",
            "#87CEFA", "#00BFFF", "#1E90FF", "#6495ED", "#7B68EE", "#4169E1", "#0000FF", "#0000CD", "#00008B", "#000080", "#191970",
            "#FFF8DC", "#FFEBCD", "#FFE4C4", "#FFDEAD", "#F5DEB3", "#DEB887", "#D2B48C", "#BC8F8F", "#F4A460", "#DAA520", "#B8860B",
            "#CD853F", "#D2691E", "#8B4513", "#A0522D", "#A52A2A", "#800000", "#FFFFFF", "#FFFAFA", "#F0FFF0", "#F5FFFA", "#F0FFFF",
            "#F0F8FF", "#F8F8FF", "#F5F5F5", "#FFF5EE", "#F5F5DC", "#FDF5E6", "#FFFAF0", "#FFFFF0", "#FAEBD7", "#FAF0E6", "#FFF0F5",
            "#FFE4E1", "#DCDCDC", "#D3D3D3", "#C0C0C0", "#A9A9A9", "#808080", "#696969", "#778899", "#708090", "#2F4F4F", "#000000",
            "#0C090A", "#2C3539", "#2B1B17", "#34282C", "#25383C", "#3B3131", "#413839", "#3D3C3A", "#463E3F", "#4C4646", "#504A4B",
            "#565051", "#5C5858", "#625D5D", "#666362", "#6D6968", "#726E6D", "#736F6E", "#837E7C", "#848482", "#B6B6B4", "#D1D0CE",
            "#E5E4E2", "#BCC6CC", "#98AFC7", "#6D7B8D", "#657383", "#616D7E", "#646D7E", "#566D7E", "#737CA1", "#4863A0", "#2B547E",
            "#2B3856", "#151B54", "#000080", "#342D7E", "#15317E", "#151B8D", "#0000A0", "#0020C2", "#0041C2", "#2554C7", "#1569C7",
            "#2B60DE", "#1F45FC", "#6960EC", "#736AFF", "#357EC7", "#368BC1", "#488AC7", "#3090C7", "#659EC7", "#87AFC7", "#95B9C7",
            "#728FCE", "#2B65EC", "#306EFF", "#157DEC", "#1589FF", "#6495ED", "#6698FF", "#38ACEC", "#56A5EC", "#5CB3FF", "#3BB9FF",
            "#79BAEC", "#82CAFA", "#82CAFF", "#A0CFEC", "#B7CEEC", "#B4CFEC", "#C2DFFF", "#C6DEFF", "#AFDCEC", "#ADDFFF", "#BDEDFF",
            "#CFECEC", "#E0FFFF", "#EBF4FA", "#F0F8FF", "#F0FFFF", "#CCFFFF", "#93FFE8", "#9AFEFF", "#7FFFD4", "#00FFFF", "#7DFDFE",
            "#57FEFF", "#8EEBEC", "#50EBEC", "#4EE2EC", "#81D8D0", "#92C7C7", "#77BFC7", "#78C7C7", "#48CCCD", "#43C6DB", "#46C7C7",
            "#7BCCB5", "#43BFC7", "#3EA99F", "#3B9C9C", "#438D80", "#348781", "#307D7E", "#5E7D7E", "#4C787E", "#008080", "#4E8975",
            "#78866B", "#848b79", "#617C58", "#728C00", "#667C26", "#254117", "#306754", "#347235", "#437C17", "#387C44", "#347C2C",
            "#347C17", "#348017", "#4E9258", "#6AA121", "#4AA02C", "#41A317", "#3EA055", "#6CBB3C", "#6CC417", "#4CC417", "#52D017",
            "#4CC552", "#54C571", "#99C68E", "#89C35C", "#85BB65", "#8BB381", "#9CB071", "#B2C248", "#9DC209", "#A1C935", "#7FE817",
            "#59E817", "#57E964", "#64E986", "#5EFB6E", "#00FF00", "#5FFB17", "#87F717", "#8AFB17", "#6AFB92", "#98FF98", "#B5EAAA",
            "#C3FDB8", "#CCFB5D", "#B1FB17", "#BCE954", "#EDDA74", "#EDE275", "#FFE87C", "#FFFF00", "#FFF380", "#FFFFC2", "#FFFFCC",
            "#FFF8C6", "#FFF8DC", "#F5F5DC", "#FBF6D9", "#FAEBD7", "#F7E7CE", "#FFEBCD", "#F3E5AB", "#ECE5B6", "#FFE5B4", "#FFDB58",
            "#FFD801", "#FDD017", "#EAC117", "#F2BB66", "#FBB917", "#FBB117", "#FFA62F", "#E9AB17", "#E2A76F", "#DEB887", "#FFCBA4",
            "#C9BE62", "#E8A317", "#EE9A4D", "#C8B560", "#D4A017", "#C2B280", "#C7A317", "#C68E17", "#B5A642", "#ADA96E", "#C19A6B",
            "#CD7F32", "#C88141", "#C58917", "#AF9B60", "#AF7817", "#B87333", "#966F33", "#806517", "#827839", "#827B60", "#786D5F",
            "#493D26", "#483C32", "#6F4E37", "#835C3B", "#7F5217", "#7F462C", "#C47451", "#C36241", "#C35817", "#C85A17", "#CC6600",
            "#E56717", "#E66C2C", "#F87217", "#F87431", "#E67451", "#FF8040", "#F88017", "#FF7F50", "#F88158", "#F9966B", "#E78A61",
            "#E18B6B", "#E77471", "#F75D59", "#E55451", "#E55B3C", "#FF0000", "#FF2400", "#F62217", "#F70D1A", "#F62817", "#E42217",
            "#E41B17", "#DC381F", "#C34A2C", "#C24641", "#C04000", "#C11B17", "#9F000F", "#990012", "#8C001A", "#954535", "#7E3517",
            "#8A4117", "#7E3817", "#800517", "#810541", "#7D0541", "#7E354D", "#7D0552", "#7F4E52", "#7F5A58", "#7F525D", "#B38481",
            "#C5908E", "#C48189", "#C48793", "#E8ADAA", "#ECC5C0", "#EDC9AF", "#FDD7E4", "#FCDFFF", "#FFDFDD", "#FBBBB9", "#FAAFBE",
            "#FAAFBA", "#F9A7B0", "#E7A1B0", "#E799A3", "#E38AAE", "#F778A1", "#E56E94", "#F660AB", "#FC6C85", "#F6358A", "#F52887",
            "#E45E9D", "#E4287C", "#F535AA", "#FF00FF", "#E3319D", "#F433FF", "#D16587", "#C25A7C", "#CA226B", "#C12869", "#C12267",
            "#C25283", "#C12283", "#B93B8F", "#7E587E", "#571B7E", "#583759", "#4B0082", "#461B7E", "#4E387E", "#614051", "#5E5A80",
            "#6A287E", "#7D1B7E", "#A74AC7", "#B048B5", "#6C2DC7", "#842DCE", "#8D38C9", "#7A5DC7", "#7F38EC", "#8E35EF", "#893BFF",
            "#8467D7", "#A23BEC", "#B041FF", "#C45AEC", "#9172EC", "#9E7BFF", "#D462FF", "#E238EC", "#C38EC7", "#C8A2C8", "#E6A9EC",
            "#E0B0FF", "#C6AEC7", "#F9B7FF", "#D2B9D3", "#E9CFEC", "#EBDDE2", "#E3E4FA", "#FDEEF4", "#FFF5EE", "#FEFCFF", "#FFFFFF" };
            return colorbox;
        }


    }
}
