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

    let { Titulo, Detalle } = req.body;

    let tarea = await Tarea.create({
        titulo: Titulo,
        detalle: Detalle
    });

    res.json(tarea);
});

module.exports = router;
