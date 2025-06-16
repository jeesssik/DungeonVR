# Proyecto Unity - Trabajo Práctico

Este proyecto es parte de un trabajo práctico que tiene como objetivo integrar distintos conceptos de desarrollo en Unity, tales como iluminación, animaciones, optimización con LOD, perspectiva en primera persona y refactorización a VR.

---

## ✅ Objetivos del Trabajo

### 📋 Correcciones pedidas

**🧩Menu del Juego**

1. ✅ Iluminación en pantalla de menu con sombras real time


**🏰Escena 1 (Dungeon)**

1. ⏳ Poner techo en el dungeon
2. ⏳ Corregir las arcadas
3. ⏳ Armar algún objeto reflectante para ver el bake del reflection probe
4. ⏳ Centrar el punto de vista inicial en el juego

<br>

---

### 🆕Nueva entrega
<br>

**🌄Nueva escena (Exterior)**
1. ⏳ Iluminación baked y luces de tipo mixed y/o real time según el criterio para cada caso.
2. ✅ Punto de vista en Primera Persona.
3. ✅ Modificar objetos o agregar con LOD.
4. ⏳ Incluir animación de objetos en loop. (Opcional: cambiar de animación según alguna interacción)
5. ⏳ Agregado de materiales con  Shader Graph

<br>

**🕶️ Refactorización a VR**
1. ⏳ Instalación de los assets y paquetes necesarios
2. ⏳ Configuración de inputs y controladores
   2.1 ⏳ Configuración de prefabs de manos y controladores
3. ⏳ Configurar los objetos interactuables
4. ⏳ Configurar teleport o movimiento libre si es necesario





---
---

## Progreso

### ✔️ [14/06/2025] Refactorización de Menú Inicial

- Duplicado de prouyecto
- Instalación de paquete de Meta (A--In-One SDK)
- Prueba de funcionalidad

### ✔️ [15/06/2025] Refactorización de Menú Inicial


- Se refactorizó la escena de menú para ser completamente funcional en VR
- Se configuraron **luces mixtas (Mixed Point Lights)** colocadas en las velas del menú
- Se activaron sombras realtime en los objetos de la habitación y el personaje
- Se revisaron los componentes del All-in-One SDK v77 en Unity 6 para el raycast desde controladores
- Se solucionaron errores visuales por falta de configuración del Universal Render Pipeline (URP)
- Se realizaron múltiples pruebas de bake de iluminación en la escena, evaluando los tiempos de procesamiento
   


### ✔️ [16/06/2025] Refactorización de Menú Inicial Parte 2

- Optimización de slider de Menú de Opciones para el correcto funcionamiento en VR
- Sonido ambiente de mení y click en botones
- Botons de inicio de jego y opciones funcionales
- Camara rota con controles pero no se permite el desplazamiento del juegador.
- Update del menu de control de volúmenes.

---
---

## 💫Estadísticas 


[![wakatime](https://wakatime.com/badge/user/d44045ec-3234-4582-bfeb-dd9364ad9986/project/408f508b-ea9c-4e08-adbb-fddcbd8901e8.svg)](https://wakatime.com/projects/Dark%20Dungeon%20VR)
