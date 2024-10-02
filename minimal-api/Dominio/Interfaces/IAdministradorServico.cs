using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
}