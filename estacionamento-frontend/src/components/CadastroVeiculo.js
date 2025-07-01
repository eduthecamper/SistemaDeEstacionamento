import React, { useState } from 'react';
import api from '../services/api';

export default function CadastroVeiculo({ onSuccess }) {
  const [placa, setPlaca] = useState('');
  const [mensagem, setMensagem] = useState('');
  const [tipo, setTipo] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setMensagem('');
    setTipo('');
    try {
      await api.post('/veiculos', { placa });
      setMensagem('Veículo cadastrado com sucesso!');
      setTipo('success');
      setPlaca('');
      if (onSuccess) onSuccess(); // chama atualização no componente pai
    } catch (err) {
      setMensagem(err.response?.data || 'Erro ao cadastrar veículo');
      setTipo('danger');
    }
  };

  return (
    <div className="card mb-3">
      <div className="card-body">
        <h5 className="card-title">Cadastrar Veículo</h5>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="Placa (ABC-1234 ou ABC1D23)"
              value={placa}
              onChange={e => setPlaca(e.target.value.toUpperCase())}
              required
            />
          </div>
          <button type="submit" className="btn btn-primary">Cadastrar</button>
        </form>
        {mensagem && (
          <div className={`alert alert-${tipo} mt-3`}>
            {mensagem}
          </div>
        )}
      </div>
    </div>
  );
}
