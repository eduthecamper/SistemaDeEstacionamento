import React, { useEffect, useState } from 'react';
import api from '../services/api';

export default function Historico({ refresh }) {
    const [historico, setHistorico] = useState([]);

    useEffect(() => {
        api.get('/historico').then(res => setHistorico(res.data));
    }, [refresh]); // Atualiza quando refresh muda

    return(
        <div className='card mb-3'>
            <div className='card-body'>
                <h5 className='card-title'>Histórico de Veículos</h5>
                <table className='table table-bordered'>
                    <thead>
                        <tr>
                            <th>Placa</th>
                            <th>Entrada</th>
                            <th>Saída</th>
                            <th>Valor Pago</th>
                        </tr>
                    </thead>
                    <tbody>
                        {historico.map((h,i) => (
                            <tr key = {i}>
                                <td>{h.placa}</td>
                                <td>{new Date(h.dataHoraEntrada).toLocaleString()}</td>
                                <td>{new Date(h.dataHoraSaida).toLocaleString()}</td>
                                <td>R$ {h.valorPago}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}
