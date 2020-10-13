using System.Collections.Generic;
using PTC.DOTIC.Chat.Dto;
using PTC.DOTIC.Dto;

namespace PTC.DOTIC.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
