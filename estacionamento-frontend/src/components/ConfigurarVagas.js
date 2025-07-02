import React, { useState, useEffect } from 'react';
import api from '../services/api';

export default function ConfigurarVagas({ onSuccess }) {
  const [quantidade, setQuantidade] = useState('');
  const [mensagem, setMensagem] = useState('');

  useEffect(() => {
    api.get('/configuracao')
      .then(res => setQuantidade(res.data.quantidadeMaximaVagas))
      .catch(() => setQuantidade(''));
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setMensagem('');
    try {
      await api.put('/configuracao', quantidade, {
        headers: { 'Content-Type': 'application/json' }
      });
      setMensagem('Quantidade de vagas atualizada!');
      if (onSuccess) onSuccess();
    } catch {
      setMensagem('Erro ao atualizar vagas.');
    }
  };

  return (
    <div className="card mb-3">
      <div className="card-body">
        <h5 className="card-title">Configurar Quantidade Máxima de Vagas</h5>
        <form onSubmit={handleSubmit}>
          <input
            type="number"
            min="1"
            className="form-control mb-2"
            value={quantidade}
            onChange={e => setQuantidade(e.target.value)}
            required
          />
          <button type="submit" className="btn btn-secondary">Salvar</button>
        </form>
        {mensagem && <div className="alert alert-info mt-2">{mensagem}</div>}
      </div>
    </div>
  );
}
