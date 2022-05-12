﻿using IntegratorProject.src.models;
using IntegratorProject.src.utilities;
using System.ComponentModel.DataAnnotations;

namespace IntegratorProject.src.dtos
{
    /// <summary>
    /// <para>Resumo:Mirror Class for create new user</para>
    /// <para>Created by: Joaoms98, Julio Conceicão,José Vinicius</para>
    /// <para>Version 1.0</para>
    /// <para>05.05.2020</para>
    /// </summary>
    public class NewUserDTO
    {
        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(14)]
        public string CPF_CNPJ { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string NameAgent { get; set; }

        [Required]
        public UserType Type { get; set; }

        public NewUserDTO(string name, string cpf_cnpj, string email, string password, string adress, string nameAgent, UserType type)
        {
            Name = name;
            CPF_CNPJ = cpf_cnpj;
            Email = email;
            Password = password;
            Adress = adress;
            NameAgent = nameAgent;
            Type = type;
        }
    }
    /// <summary>
    /// <para>Resumo:Mirror Class for create for update user</para>
    /// <para>Created by: Joaoms98, Julio Conceicão,José Vinicius</para>
    /// <para>Version 1.0</para>
    /// <para>05.05.2020</para>
    /// </summary>
    public class UpdateUserDTO   //Joao: alterado o nome do DTO de UpDate para Update em todas as referências.
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(14)]
        public int CPF_CNPJ { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Adress { get; set; }

        [StringLength(50)]
        public string NameAgent { get; set; }

        //Joao: Alteração do atributo Type do UpdateDTO pois o tipo de usuário não pode ser alterado pelo mesmo. 
        //[Required]
        //public UserType Type { get; set; }

        public UpdateUserDTO(string name, int cpf_cnpj, string email, string password, string adress, string nameAgent)
        {
            Name = name;
            CPF_CNPJ = cpf_cnpj;
            Email = email;
            Password = password;
            Adress = adress;
            NameAgent = nameAgent;
        }
    }
}