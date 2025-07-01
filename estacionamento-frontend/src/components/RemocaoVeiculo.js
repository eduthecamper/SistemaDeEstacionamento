import React, { useState } from 'react';
import api from '../services/api';

export default function RemocaoVeiculo({ onSuccess }) {
    const [placa, setPlaca] = useState('');
    const [resultado, setResultado] = useState(null);
    const [mensagem, setMensagem] = useState('');
    const [tipo, setTipo] = useState(''); 

    const handleRemover = async (e) => {
        e.preventDefault();
        setMensagem('');
        setTipo('');
        setResultado(null);
        try {
            // Use template string corretamente!
            const res = await api.delete(`/veiculos/${placa}`);
            setResultado(res.data);
            setMensagem('Veículo removido!');
            setTipo('success');
            setPlaca('');
            if (onSuccess) onSuccess(); // chama atualização no componente pai
        } catch (err) {
            setMensagem(err.response?.data || 'Erro ao remover veículo');
            setTipo('danger');
        }
    };

    return (
        <div className='card mb-3'>
            <div className='card-body'>
                <h5 className='card-title'>Remover Veículo</h5>
                <form onSubmit={handleRemover}>
                    <div className='mb-3'>
                        <input
                        type='text'
                        className='form-control'
                        placeholder='Placa'
                        value={placa}
                        onChange={e => setPlaca(e.target.value.toUpperCase())}
                        required
                        />
                    </div>
                    <button type='submit' className='btn btn-danger'>Remover</button>
                </form>
                {mensagem && <div className={`alert alert-${tipo} mt-3`}>{mensagem}</div>}
                {resultado &&(
                    <div className='mt-3'>
                        <strong>Placa:</strong> {resultado.placa}<br />
                        <strong>Valor Pago:</strong> R$ {resultado.valorPago}<br />
                        <strong>Entrada:</strong> {new Date(resultado.dataHoraEntrada).toLocaleString()}<br />
                        <strong>Saída:</strong> {new Date(resultado.dataHoraSaida).toLocaleString()}
                    </div>
                )}
            </div>
        </div>
    );
}
