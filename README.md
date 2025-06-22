# Proyecto Unity - Trabajo Práctico

Este proyecto es parte de un trabajo práctico que tiene como objetivo integrar distintos conceptos de desarrollo en Unity, tales como iluminación, animaciones, optimización con LOD, perspectiva en primera persona y refactorización a VR.

---

## ✅ Objetivos del Trabajo

### 📋 Correcciones pedidas



**🏰Escena 1 (Dungeon)**

1. ✅ Poner techo en el dungeon
2. ✅ Corregir las arcadas
3. ⏳ Armar algún objeto reflectante para ver el bake del reflection probe
4. ✅ Agregado de la vista el primera persona en VR
5. ⏳ Modificaciones de UI para VR

<br>

---

### 🆕Nueva entrega
<br>

**🌄Nueva escena (Exterior)**
1. ✅ Iluminación baked y luces de tipo mixed y/o real time según el criterio para cada caso.
2. ✅ Punto de vista en Primera Persona.
3. ✅ Modificar objetos o agregar con LOD.
4. ⏳ Incluir animación de objetos en loop. (Opcional: cambiar de animación según alguna interacción)
5. ✅ Agregado de materiales con  Shader Graph
6. ✅ Agregar agua con shader
7. ✅ Agregado de la vista el primera persona en VR

<br>

**🕶️ Refactorización a VR**
1. ✅ Instalación de los assets y paquetes necesarios
2. ⏳ Configuración de inputs y controladores
   2.1 ⏳ Configuración de prefabs de manos y controladores
3. ⏳ Configurar los objetos interactuables
4. ⏳ Configurar teleport o movimiento libre si es necesario





---
---

## Progreso

### ✔️ [22/06/2025] Avances en escenario exterior
- Armado de UI diegética, con cambios de mensaje según estado del juego
- Mensaje con pista de la misión a resovler controlado por el botón A del control Derecho para visualizar y ocultar.
![No Agua](./screens/buscaEspada.png)

- las pistas son dinámicas en base a zonas con triggers

![No Agua](./screens/espadaSI.png)



### ✔️ [21/06/2025] Armado de escenario exterior
- Agregado de decoraciones con LODS
- Agregado del agua a la escena
- Seteo de límites del escenario
- Agregado de colliders para permitir el correcto desplazamiento en el mapa
- Shader y efectos de partículas que destacan a la espada a tomar

![No Agua](./screens/shaderEspada.png)
- Agregado de la camara VR y movimiento en la escena
- Modificación de rotación de la camara, no snap turn

## No Agua
![No Agua](./screens/no_agua.png)


### Agua
![Agua](./screens/agua.png)


## ✔️ [17/06/2025] Correcciones pendientes

- Corrección es texturas de las arcadas
- Agregado de techo a calabozo
- Eliminado de la iluminación ambiente



### ✔️ [16/06/2025] Refactorización de Menú Inicial Parte 2

- Optimización de slider de Menú de Opciones para el correcto funcionamiento en VR
- Sonido ambiente de mení y click en botones
- Botons de inicio de jego y opciones funcionales
- Camara rota con controles pero no se permite el desplazamiento del juegador.
- Update del menu de control de volúmenes.
- Control de volumen en menu de configuración.





### ✔️ [15/06/2025] Refactorización de Menú Inicial


- Se refactorizó la escena de menú para ser completamente funcional en VR
- Se configuraron **luces mixtas (Mixed Point Lights)** colocadas en las velas del menú
- Se activaron sombras realtime en los objetos de la habitación y el personaje
- Se revisaron los componentes del All-in-One SDK v77 en Unity 6 para el raycast desde controladores
- Se solucionaron errores visuales por falta de configuración del Universal Render Pipeline (URP)
- Se realizaron múltiples pruebas de bake de iluminación en la escena, evaluando los tiempos de procesamiento
   
### ✔️ [14/06/2025] Refactorización de Menú Inicial

- Duplicado de prouyecto
- Instalación de paquete de Meta (A--In-One SDK)
- Prueba de funcionalidad


