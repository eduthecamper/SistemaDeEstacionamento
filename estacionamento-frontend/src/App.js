import React, { useState } from "react";
import ConfigurarVagas from "./components/ConfigurarVagas";
import Dashboard from "./components/Dashboard";
import CadastroVeiculo from "./components/CadastroVeiculo";
import RemocaoVeiculo from "./components/RemocaoVeiculo";
import ListaVeiculos from "./components/ListaVeiculos";
import Historico from "./components/Historico";
import './App.css';

function App() {
  const [refresh, setRefresh] = useState(0);
  const [mostrarConfig, setMostrarConfig] = useState(true);

  const handleRefresh = () => setRefresh(r => r + 1);

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Estacionamento</h1>
      <button
        className="btn btn-outline-secondary mb-3"
        onClick={() => setMostrarConfig(v => !v)}
      >
        {mostrarConfig ? "Ocultar Configuração" : "Definir Vagas"}
      </button>
      {mostrarConfig && <ConfigurarVagas onSuccess={handleRefresh} />}
      <Dashboard refresh={refresh} />
      <CadastroVeiculo onSuccess={handleRefresh} />
      <RemocaoVeiculo onSuccess={handleRefresh} />
      <ListaVeiculos refresh={refresh} />
      <Historico refresh={refresh} />
    </div>
  );
}

export default App;