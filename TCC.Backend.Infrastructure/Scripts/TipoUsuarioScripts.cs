using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Backend.Infrastructure.Scripts
{
    public static class TipoUsuarioScripts
    {
        public static string LISTAR = @"
                                        SELECT 
	                                        id_tipo_usuario as IdTipoUsuario,
                                            descricao_tipo_usuario as DescricaoTipoUsuario
                                        FROM 
	                                        tipo_usuario;";
    }
}
