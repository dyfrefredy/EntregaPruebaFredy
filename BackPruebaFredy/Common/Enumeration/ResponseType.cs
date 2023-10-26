using System.ComponentModel;

namespace Common.Utility
{
    public enum ResponseType : Int32
    {
        [Description("OK")]
        OK = 200,

        [Description("WARNING")]
        WARNING = 204,

        [Description("FAIL")]
        FAIL = 500,

        [Description("ERROR")]
        ERROR = 500,

        [Description("FORBIDDEN")]
        Forbidden = 403,

        [Description("PROBLEMA_VALOR_REQUERIDO")]
        PROBLEMA_VALOR_REQUERIDO = 4,

        [Description("ENTIDAD_NO_ENCONTRADA")]
        ENTIDAD_NO_ENCONTRADA = 5,

        [Description("PROBLEMA_CONSUMO_SERVICIO")]
        PROBLEMA_CONSUMO_SERVICIO = 6

    }
}
