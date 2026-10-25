using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;


namespace teste02
{





    public class DAO
    {
        public int ExcluirVenda(int codigoVenda)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao =
                    conexao.BeginTransaction())
                {
                    try
                    {
                        //Buscar o pós-venda vinculado
                        object resultado;

                        using (MySqlCommand comando = new MySqlCommand(
                            @"SELECT posVendaCodigo
                      FROM venda
                      WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@codigo", codigoVenda);

                            resultado = comando.ExecuteScalar();
                        }

                        if (resultado == null ||
                            resultado == DBNull.Value)
                        {
                            transacao.Rollback();
                            return 0;
                        }

                        int codigoPosVenda = Convert.ToInt32(resultado);

                        //excluir a venda
                        int excluidos;

                        using (MySqlCommand comando = new MySqlCommand(
                            @"DELETE FROM venda
                      WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@codigo", codigoVenda);

                            excluidos = comando.ExecuteNonQuery();
                        }

                        if (excluidos == 0)
                        {
                            transacao.Rollback();
                            return 0;
                        }

                        // Verificar se outra venda usa o mesmo pós-venda
                        int outrasVendas;

                        using (MySqlCommand comando = new MySqlCommand(
                            @"SELECT COUNT(*)
                      FROM venda
                      WHERE posVendaCodigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@codigo", codigoPosVenda);

                            outrasVendas = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        if (outrasVendas == 0)
                        {
                            //descobrir se existe seguro associado
                            object resultadoSeguro;

                            using (MySqlCommand comando = new MySqlCommand(
                                @"SELECT seguroCodigo
                          FROM posvenda
                          WHERE codigo = @codigo",
                                conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@codigo", codigoPosVenda);

                                resultadoSeguro = comando.ExecuteScalar();
                            }

                            int? codigoSeguro =
                                resultadoSeguro == null ||
                                resultadoSeguro == DBNull.Value
                                ? (int?)null
                                : Convert.ToInt32(resultadoSeguro);

                            // Excluir o pós-venda
                            using (MySqlCommand comando = new MySqlCommand(
                                @"DELETE FROM posvenda
                          WHERE codigo = @codigo",
                                conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@codigo", codigoPosVenda);

                                comando.ExecuteNonQuery();
                            }

                            if (codigoSeguro.HasValue)
                            {
                                // Verificar se outro pós-venda usa esse seguro
                                int outrosPosVendas;

                                using (MySqlCommand comando = new MySqlCommand(
                                    @"SELECT COUNT(*)
                              FROM posvenda
                              WHERE seguroCodigo = @codigo",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@codigo", codigoSeguro.Value);

                                    outrosPosVendas = Convert.ToInt32(
                                        comando.ExecuteScalar());
                                }

                                if (outrosPosVendas == 0)
                                {
                                    int? codigoVigencia = null;
                                    int? codigoCobertura = null;

                                    // Guardar os códigos antes de excluir o seguro
                                    using (MySqlCommand comando = new MySqlCommand(
                                        @"SELECT vigenciaCodigo, coberturaCodigo
                                  FROM seguroveicular
                                  WHERE codigo = @codigo",
                                        conexao, transacao))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@codigo", codigoSeguro.Value);

                                        using (MySqlDataReader leitor =
                                            comando.ExecuteReader())
                                        {
                                            if (leitor.Read())
                                            {
                                                codigoVigencia =
                                                    Convert.ToInt32(
                                                        leitor["vigenciaCodigo"]);

                                                codigoCobertura =
                                                    Convert.ToInt32(
                                                        leitor["coberturaCodigo"]);
                                            }
                                        }
                                    }

                                    // Excluir o seguro
                                    int segurosExcluidos;

                                    using (MySqlCommand comando = new MySqlCommand(
                                        @"DELETE FROM seguroveicular
                                  WHERE codigo = @codigo",
                                        conexao, transacao))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@codigo", codigoSeguro.Value);

                                        segurosExcluidos =
                                            comando.ExecuteNonQuery();
                                    }

                                    if (segurosExcluidos > 0)
                                    {
                                        // Excluir a vigência somente se não for usada
                                        if (codigoVigencia.HasValue)
                                        {
                                            using (MySqlCommand comando =
                                                new MySqlCommand(
                                                    @"DELETE FROM vigencia
                                              WHERE codigo = @codigo
                                              AND NOT EXISTS (
                                                  SELECT 1
                                                  FROM seguroveicular
                                                  WHERE vigenciaCodigo = @codigo
                                              )",
                                                    conexao, transacao))
                                            {
                                                comando.Parameters.AddWithValue(
                                                    "@codigo",
                                                    codigoVigencia.Value);

                                                comando.ExecuteNonQuery();
                                            }
                                        }

                                        // Excluir a cobertura somente se não for usada
                                        if (codigoCobertura.HasValue)
                                        {
                                            using (MySqlCommand comando =
                                                new MySqlCommand(
                                                    @"DELETE FROM cobertura
                                              WHERE codigo = @codigo
                                              AND NOT EXISTS (
                                                  SELECT 1
                                                  FROM seguroveicular
                                                  WHERE coberturaCodigo = @codigo
                                              )",
                                                    conexao, transacao))
                                            {
                                                comando.Parameters.AddWithValue(
                                                    "@codigo",
                                                    codigoCobertura.Value);

                                                comando.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // Confirmar todas as exclusões
                        transacao.Commit();

                        return excluidos;
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }





        public void AtualizarVendaCompleta(
    int codigoVenda,
    int codigoPosVenda,
    int? codigoSeguroAtual,
    DateTime dataVenda,
    DateTime? dataInicioVigencia,
    DateTime? dataFinalVigencia,
    string cpfCliente,
    string cpfVendedor,
    int codigoVeiculo,
    bool possuiSeguro,
    bool seguroParcial,
    bool seguroIntegral)
        {
            if (!long.TryParse(cpfCliente, out long cpfClienteNumero))
                throw new Exception("CPF do cliente inválido.");

            if (string.IsNullOrWhiteSpace(cpfVendedor) ||
                cpfVendedor.Length != 11 ||
                !cpfVendedor.All(char.IsDigit))
                throw new Exception("CPF do vendedor inválido.");

            if (possuiSeguro && (seguroParcial == seguroIntegral))
                throw new Exception(
                    "Selecione somente o seguro parcial ou o integral.");

            if (possuiSeguro)
            {
                if (!dataInicioVigencia.HasValue ||
                    !dataFinalVigencia.HasValue)
                    throw new Exception(
                        "Informe as datas de início e fim da vigência.");

                if (dataFinalVigencia.Value.Date <
                    dataInicioVigencia.Value.Date)
                    throw new Exception(
                        "A data final não pode ser anterior à data inicial.");
            }

            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao =
                    conexao.BeginTransaction())
                {
                    try
                    {
                        // Buscar o preço atual do veículo
                        decimal valorVeiculo;

                        using (MySqlCommand comando = new MySqlCommand(
                            "SELECT valor FROM veiculo WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@codigo", codigoVeiculo);

                            object resultado = comando.ExecuteScalar();

                            if (resultado == null ||
                                resultado == DBNull.Value)
                                throw new Exception(
                                    "O veículo informado não foi encontrado.");

                            valorVeiculo = Convert.ToDecimal(resultado);
                        }

                        decimal valorSeguro = 0m;

                        if (possuiSeguro)
                        {
                            if (seguroParcial)
                                valorSeguro = valorVeiculo * 0.05m;
                            else
                                valorSeguro = valorVeiculo * 0.10m;
                        }

                        decimal valorTotal = valorVeiculo + valorSeguro;

                        //  Buscar as referências antigas, se houver seguro
                        int? codigoVigenciaAntiga = null;
                        int? codigoCoberturaAntiga = null;

                        if (codigoSeguroAtual.HasValue)
                        {
                            using (MySqlCommand comando = new MySqlCommand(
                                @"SELECT vigenciaCodigo, coberturaCodigo
                          FROM seguroveicular
                          WHERE codigo = @codigo",
                                conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@codigo", codigoSeguroAtual.Value);

                                using (MySqlDataReader leitor =
                                    comando.ExecuteReader())
                                {
                                    if (!leitor.Read())
                                        throw new Exception(
                                            "O registro de seguro vinculado não foi encontrado.");

                                    codigoVigenciaAntiga =
                                        Convert.ToInt32(
                                            leitor["vigenciaCodigo"]);

                                    codigoCoberturaAntiga =
                                        Convert.ToInt32(
                                            leitor["coberturaCodigo"]);
                                }
                            }
                        }

                        // Tratar o seguro escolhido
                        if (possuiSeguro)
                        {
                            int codigoSeguro;

                            if (codigoSeguroAtual.HasValue)
                            {
                                // Atualizar a vigência existente
                                using (MySqlCommand comando = new MySqlCommand(
                                    @"UPDATE vigencia
                              SET dataDaCompra = @inicio,
                                  dataDeFinal = @fim
                              WHERE codigo = @codigo",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@inicio",
                                        dataInicioVigencia.Value.Date);
                                    comando.Parameters.AddWithValue(
                                        "@fim",
                                        dataFinalVigencia.Value.Date);
                                    comando.Parameters.AddWithValue(
                                        "@codigo",
                                        codigoVigenciaAntiga.Value);

                                    comando.ExecuteNonQuery();
                                }

                                // Atualizar a cobertura existente
                                using (MySqlCommand comando = new MySqlCommand(
                                    @"UPDATE cobertura
                              SET parcial = @parcial,
                                  total = @total
                              WHERE codigo = @codigo",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@parcial", seguroParcial ? 1 : 0);
                                    comando.Parameters.AddWithValue(
                                        "@total", seguroIntegral ? 1 : 0);
                                    comando.Parameters.AddWithValue(
                                        "@codigo",
                                        codigoCoberturaAntiga.Value);

                                    comando.ExecuteNonQuery();
                                }

                                // Atualizar o valor do seguro
                                codigoSeguro = codigoSeguroAtual.Value;

                                using (MySqlCommand comando = new MySqlCommand(
                                    @"UPDATE seguroveicular
                              SET valor = @valor
                              WHERE codigo = @codigo",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@valor", valorSeguro);
                                    comando.Parameters.AddWithValue(
                                        "@codigo", codigoSeguro);

                                    comando.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Criar uma nova vigência
                                using (MySqlCommand comando = new MySqlCommand(
                                    @"INSERT INTO vigencia
                              (dataDaCompra, dataDeFinal)
                              VALUES (@inicio, @fim)",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@inicio",
                                        dataInicioVigencia.Value.Date);
                                    comando.Parameters.AddWithValue(
                                        "@fim",
                                        dataFinalVigencia.Value.Date);

                                    comando.ExecuteNonQuery();
                                }

                                int novoCodigoVigencia =
                                    ObterUltimoId(conexao, transacao);

                                // Criar uma nova cobertura
                                using (MySqlCommand comando = new MySqlCommand(
                                    @"INSERT INTO cobertura (parcial, total)
                              VALUES (@parcial, @total)",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@parcial", seguroParcial ? 1 : 0);
                                    comando.Parameters.AddWithValue(
                                        "@total", seguroIntegral ? 1 : 0);

                                    comando.ExecuteNonQuery();
                                }

                                int novoCodigoCobertura =
                                    ObterUltimoId(conexao, transacao);

                                // Criar o registro do seguro
                                using (MySqlCommand comando = new MySqlCommand(
                                    @"INSERT INTO seguroveicular
                              (valor, vigenciaCodigo, coberturaCodigo)
                              VALUES (@valor, @vigencia, @cobertura)",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@valor", valorSeguro);
                                    comando.Parameters.AddWithValue(
                                        "@vigencia", novoCodigoVigencia);
                                    comando.Parameters.AddWithValue(
                                        "@cobertura", novoCodigoCobertura);

                                    comando.ExecuteNonQuery();
                                }

                                codigoSeguro =
                                    ObterUltimoId(conexao, transacao);
                            }

                            // Vincular o seguro ao pós-venda
                            using (MySqlCommand comando = new MySqlCommand(
                                @"UPDATE posvenda
                          SET seguroCodigo = @seguro,
                              seguro = 1
                          WHERE codigo = @posVenda",
                                conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@seguro", codigoSeguro);
                                comando.Parameters.AddWithValue(
                                    "@posVenda", codigoPosVenda);

                                if (comando.ExecuteNonQuery() == 0)
                                    throw new Exception(
                                        "O registro de pós-venda não foi encontrado.");
                            }
                        }
                        else
                        {
                            // Remover a associação ao seguro
                            using (MySqlCommand comando = new MySqlCommand(
                                @"UPDATE posvenda
                          SET seguroCodigo = NULL,
                              seguro = 0
                          WHERE codigo = @posVenda",
                                conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@posVenda", codigoPosVenda);

                                comando.ExecuteNonQuery();
                            }

                            // Remover o seguro antigo somente se não for usado
                            // por nenhum outro registro de pós-venda.
                            if (codigoSeguroAtual.HasValue)
                            {
                                int removidos;

                                using (MySqlCommand comando = new MySqlCommand(
                                    @"DELETE FROM seguroveicular
                              WHERE codigo = @seguro
                              AND NOT EXISTS (
                                  SELECT 1 FROM posvenda
                                  WHERE seguroCodigo = @seguro
                              )",
                                    conexao, transacao))
                                {
                                    comando.Parameters.AddWithValue(
                                        "@seguro", codigoSeguroAtual.Value);

                                    removidos = comando.ExecuteNonQuery();
                                }

                                if (removidos > 0)
                                {
                                    using (MySqlCommand comando = new MySqlCommand(
                                        @"DELETE FROM vigencia
                                  WHERE codigo = @codigo
                                  AND NOT EXISTS (
                                      SELECT 1 FROM seguroveicular
                                      WHERE vigenciaCodigo = @codigo
                                  )",
                                        conexao, transacao))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@codigo",
                                            codigoVigenciaAntiga.Value);

                                        comando.ExecuteNonQuery();
                                    }

                                    using (MySqlCommand comando = new MySqlCommand(
                                        @"DELETE FROM cobertura
                                  WHERE codigo = @codigo
                                  AND NOT EXISTS (
                                      SELECT 1 FROM seguroveicular
                                      WHERE coberturaCodigo = @codigo
                                  )",
                                        conexao, transacao))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@codigo",
                                            codigoCoberturaAntiga.Value);

                                        comando.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // Atualizar a venda
                        using (MySqlCommand comando = new MySqlCommand(
                            @"UPDATE venda
                      SET dataDaVenda = @data,
                          valorTotal = @total,
                          clienteCpf = @cliente,
                          vendedorCpf = @vendedor,
                          veiculoCodigo = @veiculo
                      WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@data", dataVenda);
                            comando.Parameters.AddWithValue(
                                "@total", valorTotal);
                            comando.Parameters.AddWithValue(
                                "@cliente", cpfClienteNumero);
                            comando.Parameters.AddWithValue(
                                "@vendedor", cpfVendedor);
                            comando.Parameters.AddWithValue(
                                "@veiculo", codigoVeiculo);
                            comando.Parameters.AddWithValue(
                                "@codigo", codigoVenda);

                            if (comando.ExecuteNonQuery() == 0)
                                throw new Exception(
                                    "A venda não foi encontrada para atualizar.");
                        }

                        // Confirmar todas as alterações juntas
                        transacao.Commit();
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }








































        public DataTable BuscarVendaPorCodigo(int codigo)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT
                v.codigo,
                v.dataDaVenda,
                v.localDaVenda,
                v.valorTotal,
                v.clienteCpf,
                v.vendedorCpf,
                v.veiculoCodigo,
                v.posVendaCodigo,

                pv.seguro AS possuiSeguro,
                pv.seguroCodigo,

                sv.codigo AS seguroCodigoReal,
                sv.valor AS valorSeguro,

                vg.dataDaCompra,
                vg.dataDeFinal,

                cob.parcial,
                cob.total

            FROM venda v

            LEFT JOIN posvenda pv
                ON v.posVendaCodigo = pv.codigo

            LEFT JOIN seguroveicular sv
                ON pv.seguroCodigo = sv.codigo

            LEFT JOIN vigencia vg
                ON sv.vigenciaCodigo = vg.codigo

            LEFT JOIN cobertura cob
                ON sv.coberturaCodigo = cob.codigo

            WHERE v.codigo = @codigo
            LIMIT 1;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();
                        adaptador.Fill(tabela);
                        return tabela;
                    }
                }
            }
        }

        public DataTable ListarVendas()
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT
                v.codigo,
                v.dataDaVenda,
                v.localDaVenda,
                v.valorTotal,
                v.clienteCpf,
                c.nome AS nomeCliente,
                v.vendedorCpf,
                cv.nome AS nomeVendedor,
                v.veiculoCodigo,
                ve.modelo AS modeloVeiculo,
                pv.seguro,
                sv.valor AS valorSeguro,
                vg.dataDeFinal AS dataFinalVigencia,
                cob.parcial,
                cob.total
            FROM venda v
            LEFT JOIN cliente c
                ON v.clienteCpf = c.cpf
            LEFT JOIN cadastrovendedor cv
                ON v.vendedorCpf = cv.cpf
            LEFT JOIN veiculo ve
                ON v.veiculoCodigo = ve.codigo
            LEFT JOIN posvenda pv
                ON v.posVendaCodigo = pv.codigo
            LEFT JOIN seguroveicular sv
                ON pv.seguroCodigo = sv.codigo
            LEFT JOIN vigencia vg
                ON sv.vigenciaCodigo = vg.codigo
            LEFT JOIN cobertura cob
                ON sv.coberturaCodigo = cob.codigo
            ORDER BY v.codigo DESC;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();
                        adaptador.Fill(tabela);
                        return tabela;
                    }
                }
            }
        }











        private int ObterUltimoId(
    MySqlConnection conexao,
    MySqlTransaction transacao)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "SELECT LAST_INSERT_ID();",
                conexao,
                transacao))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        public int RegistrarVendaCompleta(
    DateTime dataVenda,
    string cpfCliente,
    string cpfVendedor,
    int codigoVeiculo,
    decimal valorVeiculo,
    decimal valorTotal,
    bool possuiSeguro,
    string tipoSeguro,
    DateTime? dataFinalVigencia)
        {
            if (!long.TryParse(cpfCliente, out long cpfClienteNumero))
            {
                throw new Exception("O CPF do cliente é inválido.");
            }

            int codigoVenda;

            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        int codigoPosVenda;
                        int? codigoSeguro = null;

                        // Se tiver cadastrar vigência cobertura e seguro
                        if (possuiSeguro)
                        {
                            if (!dataFinalVigencia.HasValue)
                            {
                                throw new Exception(
                                    "Informe a data final da vigência."
                                );
                            }

                            DateTime dataFinal = dataFinalVigencia.Value.Date;

                            if (dataFinal < dataVenda.Date)
                            {
                                throw new Exception(
                                    "A data final não pode ser anterior à data da venda."
                                );
                            }

                            bool parcial = tipoSeguro == "Parcial";
                            bool integral = tipoSeguro == "Integral";

                            if (!parcial && !integral)
                            {
                                throw new Exception("Tipo de seguro inválido.");
                            }

                            //  cadastrar a vigência
                            string sqlVigencia = @"
                        INSERT INTO vigencia
                            (dataDaCompra, dataDeFinal)
                        VALUES
                            (@dataCompra, @dataFinal);";

                            using (MySqlCommand comando = new MySqlCommand(
                                sqlVigencia, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@dataCompra", dataVenda.Date);
                                comando.Parameters.AddWithValue(
                                    "@dataFinal", dataFinal);

                                comando.ExecuteNonQuery();
                            }

                            int codigoVigencia =
                                ObterUltimoId(conexao, transacao);

                            //cadastrar a cobertura escolhida
                            string sqlCobertura = @"
                        INSERT INTO cobertura (parcial, total)
                        VALUES (@parcial, @total);";

                            using (MySqlCommand comando = new MySqlCommand(
                                sqlCobertura, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@parcial", parcial ? 1 : 0);
                                comando.Parameters.AddWithValue(
                                    "@total", integral ? 1 : 0);

                                comando.ExecuteNonQuery();
                            }

                            int codigoCobertura =
                                ObterUltimoId(conexao, transacao);

                            //cadastrar o seguro
                            decimal valorSeguro = valorTotal - valorVeiculo;

                            string sqlSeguro = @"
                        INSERT INTO seguroveicular
                            (valor, vigenciaCodigo, coberturaCodigo)
                        VALUES
                            (@valor, @vigencia, @cobertura);";

                            using (MySqlCommand comando = new MySqlCommand(
                                sqlSeguro, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@valor", valorSeguro);
                                comando.Parameters.AddWithValue(
                                    "@vigencia", codigoVigencia);
                                comando.Parameters.AddWithValue(
                                    "@cobertura", codigoCobertura);

                                comando.ExecuteNonQuery();
                            }

                            codigoSeguro = ObterUltimoId(conexao, transacao);
                        }

                        //cadastrar o pós-venda
                        string sqlPosVenda = @"
                    INSERT INTO posvenda (seguroCodigo, seguro)
                    VALUES (@seguroCodigo, @seguro);";

                        using (MySqlCommand comando = new MySqlCommand(
                            sqlPosVenda, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@seguroCodigo",
                                codigoSeguro.HasValue
                                    ? (object)codigoSeguro.Value
                                    : DBNull.Value);

                            comando.Parameters.AddWithValue(
                                "@seguro", possuiSeguro ? 1 : 0);

                            comando.ExecuteNonQuery();
                        }

                        codigoPosVenda =
                            ObterUltimoId(conexao, transacao);

                        //cadastrar a venda
                        string sqlVenda = @"
                    INSERT INTO venda
                    (
                        dataDaVenda,
                        localDaVenda,
                        valorTotal,
                        posVendaCodigo,
                        vendedorCpf,
                        clienteCpf,
                        veiculoCodigo
                    )
                    VALUES
                    (
                        @data,
                        @local,
                        @valor,
                        @posVenda,
                        @vendedor,
                        @cliente,
                        @veiculo
                    );";

                        using (MySqlCommand comando = new MySqlCommand(
                            sqlVenda, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@data", dataVenda);
                            comando.Parameters.AddWithValue(
                                "@local", "Concessionária");
                            comando.Parameters.AddWithValue(
                                "@valor", valorTotal);
                            comando.Parameters.AddWithValue(
                                "@posVenda", codigoPosVenda);
                            comando.Parameters.AddWithValue(
                                "@vendedor", cpfVendedor);
                            comando.Parameters.AddWithValue(
                                "@cliente", cpfClienteNumero);
                            comando.Parameters.AddWithValue(
                                "@veiculo", codigoVeiculo);

                            comando.ExecuteNonQuery();
                        }

                        codigoVenda = ObterUltimoId(conexao, transacao);

                      
                        transacao.Commit();

                        return codigoVenda;
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable BuscarVeiculoPorCodigo(int codigo)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT
                codigo,
                chassi,
                modelo,
                ano,
                cor,
                valor
            FROM veiculo
            WHERE codigo = @codigo
            LIMIT 1;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();
                        adaptador.Fill(tabela);
                        return tabela;
                    }
                }
            }
        }











        public void AtualizarVeiculo(
    int codigoVeiculo,
    int codigoEspecificacao,
    string modelo,
    int ano,
    string chassi,
    string cor,
    decimal valor,
    string combustivel,
    string direcao,
    string arCondicionado,
    string centralMultimidia,
    string portas,
    long quilometragem,
    string bancos)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao =
                    conexao.BeginTransaction())
                {
                    try
                    {
                        // Atualizar os dados principais do veículo
                        string sqlVeiculo = @"
                    UPDATE veiculo
                    SET
                        modelo = @modelo,
                        ano = @ano,
                        chassi = @chassi,
                        cor = @cor,
                        valor = @valor
                    WHERE codigo = @codigoVeiculo;
                ";

                        using (MySqlCommand comando =
                            new MySqlCommand(sqlVeiculo, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue("@modelo", modelo);
                            comando.Parameters.AddWithValue("@ano", ano);
                            comando.Parameters.AddWithValue("@chassi", chassi);
                            comando.Parameters.AddWithValue("@cor", cor);
                            comando.Parameters.AddWithValue("@valor", valor);
                            comando.Parameters.AddWithValue(
                                "@codigoVeiculo", codigoVeiculo);

                            comando.ExecuteNonQuery();
                        }

                        if (codigoEspecificacao > 0)
                        {
                            // Atualizar as especificações existentes
                            string sqlEspecificacao = @"
                        UPDATE especificacao
                        SET
                            combustivel = @combustivel,
                            direcao = @direcao,
                            arCondicionado = @arCondicionado,
                            centralMultimidia = @centralMultimidia,
                            portas = @portas,
                            quilometragem = @quilometragem,
                            bancos = @bancos
                        WHERE codigo = @codigoEspecificacao;
                    ";

                            using (MySqlCommand comando =
                                new MySqlCommand(
                                    sqlEspecificacao, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@combustivel", combustivel);
                                comando.Parameters.AddWithValue(
                                    "@direcao", direcao);
                                comando.Parameters.AddWithValue(
                                    "@arCondicionado", arCondicionado);
                                comando.Parameters.AddWithValue(
                                    "@centralMultimidia", centralMultimidia);
                                comando.Parameters.AddWithValue(
                                    "@portas", portas);
                                comando.Parameters.AddWithValue(
                                    "@quilometragem", quilometragem);
                                comando.Parameters.AddWithValue(
                                    "@bancos", bancos);
                                comando.Parameters.AddWithValue(
                                    "@codigoEspecificacao", codigoEspecificacao);

                                comando.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Se ainda não existem especificações, cadastrá-las
                            string sqlNovaEspecificacao = @"
                        INSERT INTO especificacao
                        (
                            combustivel, direcao, arCondicionado,
                            centralMultimidia, portas, quilometragem, bancos
                        )
                        VALUES
                        (
                            @combustivel, @direcao, @arCondicionado,
                            @centralMultimidia, @portas, @quilometragem, @bancos
                        );
                    ";

                            using (MySqlCommand comando =
                                new MySqlCommand(
                                    sqlNovaEspecificacao, conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@combustivel", combustivel);
                                comando.Parameters.AddWithValue(
                                    "@direcao", direcao);
                                comando.Parameters.AddWithValue(
                                    "@arCondicionado", arCondicionado);
                                comando.Parameters.AddWithValue(
                                    "@centralMultimidia", centralMultimidia);
                                comando.Parameters.AddWithValue(
                                    "@portas", portas);
                                comando.Parameters.AddWithValue(
                                    "@quilometragem", quilometragem);
                                comando.Parameters.AddWithValue(
                                    "@bancos", bancos);

                                comando.ExecuteNonQuery();
                            }

                            int novoCodigoEspecificacao;

                            using (MySqlCommand comando =
                                new MySqlCommand(
                                    "SELECT LAST_INSERT_ID();",
                                    conexao, transacao))
                            {
                                novoCodigoEspecificacao = Convert.ToInt32(
                                    comando.ExecuteScalar());
                            }

                            // Vincular as novas especificações ao veículo
                            using (MySqlCommand comando =
                                new MySqlCommand(
                                    @"UPDATE veiculo
                              SET especificacaoCodigo = @codigoEspecificacao
                              WHERE codigo = @codigoVeiculo;",
                                    conexao, transacao))
                            {
                                comando.Parameters.AddWithValue(
                                    "@codigoEspecificacao",
                                    novoCodigoEspecificacao);
                                comando.Parameters.AddWithValue(
                                    "@codigoVeiculo", codigoVeiculo);

                                comando.ExecuteNonQuery();
                            }
                        }

                        transacao.Commit();
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }


        public int BuscarCodigoVeiculoPorChassi(string chassi)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT codigo
            FROM veiculo
            WHERE chassi = @chassi
            LIMIT 1;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue(
                        "@chassi", chassi.Trim()
                    );

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToInt32(resultado);
                }
            }
        }

        public DataTable BuscarVeiculoPorChassi(string chassi)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT
                v.codigo,
                v.chassi,
                v.modelo,
                v.ano,
                v.cor,
                v.valor,
                v.especificacaoCodigo,
                e.combustivel,
                e.direcao,
                e.arCondicionado,
                e.centralMultimidia,
                e.portas,
                e.quilometragem,
                e.bancos
            FROM veiculo v
            LEFT JOIN especificacao e
                ON v.especificacaoCodigo = e.codigo
            WHERE v.chassi = @chassi
            LIMIT 1;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue(
                        "@chassi", chassi.Trim()
                    );

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();
                        adaptador.Fill(tabela);
                        return tabela;
                    }
                }
            }
        }




        public int ExcluirVeiculo(int codigo)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        // Descobrir quais especificações pertencem ao veículo
                        object resultado;

                        using (MySqlCommand comando = new MySqlCommand(
                            "SELECT especificacaoCodigo FROM veiculo WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue("@codigo", codigo);
                            resultado = comando.ExecuteScalar();
                        }

                        if (resultado == null || resultado == DBNull.Value)
                        {
                            transacao.Rollback();
                            return 0;
                        }

                        int codigoEspecificacao = Convert.ToInt32(resultado);

                        // Excluir o veículo
                        int removidos;

                        using (MySqlCommand comando = new MySqlCommand(
                            "DELETE FROM veiculo WHERE codigo = @codigo",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue("@codigo", codigo);
                            removidos = comando.ExecuteNonQuery();
                        }

                        // Excluir as especificações se nenhum outro veículo as usar
                        using (MySqlCommand comando = new MySqlCommand(
                            @"DELETE FROM especificacao
                      WHERE codigo = @codigoEspecificacao
                      AND NOT EXISTS (
                          SELECT 1 FROM veiculo
                          WHERE especificacaoCodigo = @codigoEspecificacao
                      )",
                            conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@codigoEspecificacao", codigoEspecificacao);

                            comando.ExecuteNonQuery();
                        }

                        transacao.Commit();
                        return removidos;
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }



        public DataTable ListarVeiculos()
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT
                v.codigo,
                v.chassi,
                v.modelo,
                v.ano,
                v.cor,
                v.valor,
                e.combustivel,
                e.direcao,
                e.arCondicionado,
                e.centralMultimidia,
                e.portas,
                e.quilometragem,
                e.bancos
            FROM veiculo v
            LEFT JOIN especificacao e
                ON v.especificacaoCodigo = e.codigo
            ORDER BY v.codigo;
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();

                        adaptador.Fill(tabela);

                        return tabela;
                    }
                }
            }
        }




        public void CadastrarEspecificacoesVeiculo(
    int codigoVeiculo,
    string combustivel,
    string direcao,
    string arCondicionado,
    string centralMultimidia,
    string portas,
    long quilometragem,
    string bancos)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                using (MySqlTransaction transacao = conexao.BeginTransaction())
                {
                    try
                    {
                        // 1. Cadastrar as especificações
                        string sql = @"
                    INSERT INTO especificacao
                    (
                        combustivel,
                        direcao,
                        arCondicionado,
                        centralMultimidia,
                        portas,
                        quilometragem,
                        bancos
                    )
                    VALUES
                    (
                        @combustivel,
                        @direcao,
                        @arCondicionado,
                        @centralMultimidia,
                        @portas,
                        @quilometragem,
                        @bancos
                    );";

                        using (MySqlCommand comando =
                            new MySqlCommand(sql, conexao, transacao))
                        {
                            comando.Parameters.AddWithValue(
                                "@combustivel", combustivel);
                            comando.Parameters.AddWithValue(
                                "@direcao", direcao);
                            comando.Parameters.AddWithValue(
                                "@arCondicionado", arCondicionado);
                            comando.Parameters.AddWithValue(
                                "@centralMultimidia", centralMultimidia);
                            comando.Parameters.AddWithValue(
                                "@portas", portas);
                            comando.Parameters.AddWithValue(
                                "@quilometragem", quilometragem);
                            comando.Parameters.AddWithValue(
                                "@bancos", bancos);

                            comando.ExecuteNonQuery();
                        }

                        // 2. Descobrir o código gerado para as especificações
                        int codigoEspecificacao;

                        using (MySqlCommand comandoCodigo =
                            new MySqlCommand(
                                "SELECT LAST_INSERT_ID();",
                                conexao,
                                transacao))
                        {
                            codigoEspecificacao = Convert.ToInt32(
                                comandoCodigo.ExecuteScalar());
                        }

                        // 3. Vincular as especificações ao veículo
                        string sqlAtualizar = @"
                    UPDATE veiculo
                    SET especificacaoCodigo = @especificacaoCodigo
                    WHERE codigo = @codigoVeiculo;";

                        using (MySqlCommand comandoAtualizar =
                            new MySqlCommand(
                                sqlAtualizar,
                                conexao,
                                transacao))
                        {
                            comandoAtualizar.Parameters.AddWithValue(
                                "@especificacaoCodigo", codigoEspecificacao);
                            comandoAtualizar.Parameters.AddWithValue(
                                "@codigoVeiculo", codigoVeiculo);

                            int resultado = comandoAtualizar.ExecuteNonQuery();

                            if (resultado == 0)
                            {
                                throw new Exception(
                                    "O veículo não foi encontrado para vincular as especificações.");
                            }
                        }

                        // Confirmar os dois registros
                        transacao.Commit();
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }
            }
        }















        public int CadastrarVeiculo(
    string chassi,
    string modelo,
    int ano,
    string cor,
    decimal valor)
        {
            using (MySqlConnection conexao =
                new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            INSERT INTO veiculo
                (chassi, modelo, ano, cor, valor, especificacaoCodigo)
            VALUES
                (@chassi, @modelo, @ano, @cor, @valor, NULL);
        ";

                using (MySqlCommand comando =
                    new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@chassi", chassi);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@ano", ano);
                    comando.Parameters.AddWithValue("@cor", cor);
                    comando.Parameters.AddWithValue("@valor", valor);

                    comando.ExecuteNonQuery();
                }

                using (MySqlCommand comandoCodigo =
                    new MySqlCommand("SELECT LAST_INSERT_ID();", conexao))
                {
                    return Convert.ToInt32(comandoCodigo.ExecuteScalar());
                }
            }
        }









        public int AtualizarVendedor(
    string cpfOriginal,
    string cpfNovo,
    string nome,
    string email,
    string telefone,
    string logradouro,
    string numero,
    string bairro,
    string cidade,
    string estado,
    string cep)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            UPDATE cadastrovendedor
            SET cpf = @cpfNovo,
                nome = @nome,
                email = @email,
                telefone = @telefone,
                logradouro = @logradouro,
                numero = @numero,
                bairro = @bairro,
                cidade = @cidade,
                estado = @estado,
                cep = @cep
            WHERE cpf = @cpfOriginal";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpfOriginal", cpfOriginal);
                    comando.Parameters.AddWithValue("@cpfNovo", cpfNovo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@logradouro", logradouro);
                    comando.Parameters.AddWithValue("@numero", numero);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@cep", cep);

                    return comando.ExecuteNonQuery();
                }
            }
        }






        public DataTable BuscarVendedorPorCpf(string cpf)
        {
            DataTable vendedor = new DataTable();

            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT codigo, cpf, nome, email, telefone,
                   logradouro, numero, bairro, cidade, estado, cep
            FROM cadastrovendedor
            WHERE cpf = @cpf
            LIMIT 1";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(vendedor);
                    }
                }
            }

            return vendedor;
        }







        public int ExcluirVendedor(string cpf)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql =
                    "DELETE FROM cadastrovendedor WHERE cpf = @cpf";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    return comando.ExecuteNonQuery();
                }
            }
        }




        public DataTable ListarVendedores()
        {
            DataTable vendedores = new DataTable();

            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT codigo, cpf, nome, email, telefone,
                   logradouro, numero, bairro, cidade, estado, cep
            FROM cadastrovendedor
            ORDER BY codigo";

                using (MySqlDataAdapter adaptador =
                       new MySqlDataAdapter(sql, conexao))
                {
                    adaptador.Fill(vendedores);
                }
            }

            return vendedores;
        }


        public void CadastrarVendedor(
    string cpf,
    string nome,
    string email,
    string telefone,
    string logradouro,
    string numero,
    string bairro,
    string cidade,
    string estado,
    string cep)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            INSERT INTO cadastrovendedor
            (cpf, nome, email, telefone, logradouro,
             numero, bairro, cidade, estado, cep)
            VALUES
            (@cpf, @nome, @email, @telefone, @logradouro,
             @numero, @bairro, @cidade, @estado, @cep)";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@logradouro", logradouro);
                    comando.Parameters.AddWithValue("@numero", numero);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@cep", cep);

                    comando.ExecuteNonQuery();
                }
            }
        }
















        public int AtualizarCliente(
    long cpfOriginal,
    long cpfNovo,
    string nome,
    string email,
    string telefone,
    string logradouro,
    string numero,
    string bairro,
    string cidade,
    string estado,
    string cep)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            UPDATE cliente
            SET cpf = @cpfNovo,
                nome = @nome,
                email = @email,
                telefone = @telefone,
                logradouro = @logradouro,
                numero = @numero,
                bairro = @bairro,
                cidade = @cidade,
                estado = @estado,
                cep = @cep
            WHERE cpf = @cpfOriginal";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpfOriginal", cpfOriginal);
                    comando.Parameters.AddWithValue("@cpfNovo", cpfNovo);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@logradouro", logradouro);
                    comando.Parameters.AddWithValue("@numero", numero);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@cep", cep);

                    return comando.ExecuteNonQuery();
                }
            }
        }
























        public DataTable BuscarClientePorCpf(long cpf)
        {
            DataTable cliente = new DataTable();

            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT codigo, cpf, nome, email, telefone,
                   logradouro, numero, bairro, cidade, estado, cep
            FROM cliente
            WHERE cpf = @cpf
            LIMIT 1";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(cliente);
                    }
                }
            }

            return cliente;
        }




















        public int ExcluirCliente(long cpf)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = "DELETE FROM cliente WHERE cpf = @cpf";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    return comando.ExecuteNonQuery();
                }
            }
        }

        public DataTable ListarClientes()
        {
            DataTable clientes = new DataTable();

            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            SELECT codigo, cpf, nome, email, telefone,
                   logradouro, numero, bairro, cidade, estado, cep
            FROM cliente
            ORDER BY codigo";

                using (MySqlDataAdapter adaptador =
                       new MySqlDataAdapter(sql, conexao))
                {
                    adaptador.Fill(clientes);
                }
            }

            return clientes;
        }








        private readonly string connectionString =
            "Server=localhost;Port=3306;Database=dbconcessionaria;Uid=root;Pwd=;";

        public void TestarConexao()
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();
            }
        }

        public void CadastrarCliente(
    long cpf,
    string nome,
    string email,
    string telefone,
    string logradouro,
    string numero,
    string bairro,
    string cidade,
    string estado,
    string cep)
        {
            using (MySqlConnection conexao =
                   new MySqlConnection(connectionString))
            {
                conexao.Open();

                string sql = @"
            INSERT INTO cliente
            (cpf, nome, email, telefone, logradouro,
             numero, bairro, cidade, estado, cep)
            VALUES
            (@cpf, @nome, @email, @telefone, @logradouro,
             @numero, @bairro, @cidade, @estado, @cep)";

                using (MySqlCommand comando =
                       new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@logradouro", logradouro);
                    comando.Parameters.AddWithValue("@numero", numero);
                    comando.Parameters.AddWithValue("@bairro", bairro);
                    comando.Parameters.AddWithValue("@cidade", cidade);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@cep", cep);

                    comando.ExecuteNonQuery();
                }
            }










        } //fim do dao


    }






}

