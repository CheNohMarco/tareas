'use strict';

var Tarea = require('../models/Tarea');
var express = require('express');
var router = express.Router();

/* GET tareas listing. */
router.get('/', async function (req, res) {
    const tareas = await Tarea.findAll();
    res.json(tareas);
});

router.post('/', async function (req, res) {

    let { Titulo, Detalle, Fecha, Asignado } = req.body;

    let tarea = await Tarea.create({
        titulo: Titulo,
        detalle: Detalle,
        fecha: Fecha,
        asignado: Asignado
    });

    res.json(tarea);
});

router.delete('/:id', async (req, res) => {

    const message = await Tarea
        .destroy({ where: { id: req.params.id } })
        .then(() => 'List deleted');

    res.json({ message });
});

router.put('/:id', async (req, res) => {
    console.log(req.body);
    var t = req.body;
    const message = await Tarea.findByPk(req.params.id)
        .then(tarea => {
            tarea.update(t);
            tarea.save();
            'List updated'
        });

    res.json({ t });

});

module.exports = router;
