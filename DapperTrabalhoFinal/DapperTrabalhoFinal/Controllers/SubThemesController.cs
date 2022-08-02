﻿using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubThemesController
    {

        [HttpGet]

        public IEnumerable<SubThemes> ListSubThemes()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<SubThemes>("SELECT * FROM sub_themes").ToList();
        }

        [HttpPost]

        public string RegisterSubThemes([FromBody] SubThemes st)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO sub_themes (sub_theme_name, id_subcategory) VALUES (:Sub_theme_name, :Id_subcategory)", st);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateSubThemes([FromBody] SubThemes st)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE sub_themes SET sub_theme_name = :Sub_theme_name, id_subcategory = :Id_subcategory WHERE id_sub_theme = :Id_sub_theme", st);

            return "Sub tema alterado com sucesso!";
        }

        [HttpDelete("{id_sub_theme}")]

        public string DeleteSubThemes(int id_sub_theme)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_sub_theme);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM sub_themes WHERE id_sub_theme = " + id_sub_theme);
                return "Sub tema removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção do sub tema {count}";
            }
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM sub_themes WHERE id_sub_theme = " + id);
        }
    }
}
