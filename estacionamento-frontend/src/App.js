import React, { useState } from "react";
import Dashboard from "./components/Dashboard";
import CadastroVeiculo from "./components/CadastroVeiculo";
import RemocaoVeiculo from "./components/RemocaoVeiculo";
import ListaVeiculos from "./components/ListaVeiculos";
import Historico from "./components/Historico";
import './App.css';

function App() {
  const [refresh, setRefresh] = useState(0);

  // Função para atualizar o refresh
  const handleRefresh = () => setRefresh(r => r + 1);

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Estacionamento</h1>
      <Dashboard refresh={refresh} />
      <CadastroVeiculo onSuccess={handleRefresh} />
      <RemocaoVeiculo onSuccess={handleRefresh} />
      <ListaVeiculos refresh={refresh} />
      <Historico refresh={refresh} />
    </div>
  );
}

export default App;
