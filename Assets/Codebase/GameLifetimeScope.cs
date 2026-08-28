using UnityEngine;
using Unity.Cinemachine;
using VContainer;
using VContainer.Unity;
using System;
using System.Collections.Generic;
using Infrastructure.Events;
using Infrastructure.Interfaces;
using Infrastructure.Input;
using Infrastructure.Time;
using Infrastructure.Unity;
using Infrastructure.States;
using Mechanics.Controllers;
using Mechanics.Movement;
using Mechanics.Scripts;
using Mechanics.Triggers;
using Mechanics.Inventory;
using Mechanics.UI;

namespace Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]private CharacterController controller;
        [SerializeField]private PlayerConfig config;
        [SerializeField]private CinemachineCamera playerCamera;
        [SerializeField]private Transform playerTransform;

        [Header("Scripts")]
        [SerializeField]private List<PassThroughPointScript> pointScripts;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(config);

            builder.Register<ITimeProvider, UnityTimeProvider>(Lifetime.Singleton);
            builder.Register<IMovementController, UnityMovementController>(Lifetime.Singleton)
                .WithParameter(controller);
            builder.Register<ICameraController, UnityCameraController>(Lifetime.Singleton)
                .WithParameter(playerCamera);
            
            builder.Register<PlayerInputHandler>(Lifetime.Singleton)
                .AsSelf()
                .As<IDisposable>(); 
            
            builder.Register<MovementFactory>(Lifetime.Transient);
            builder.Register<PlayerGravity>(Lifetime.Singleton);
            builder.RegisterEntryPoint<PlayerWalkController>();
            builder.RegisterEntryPoint<PlayerCameraController>();

            builder.RegisterInstance(pointScripts).As<IEnumerable<IGameScript>>();

            builder.Register<EventBus>(Lifetime.Singleton);
            builder.Register<ScriptsFacade>(Lifetime.Singleton);
            builder.Register<ScriptsRunner>(Lifetime.Singleton)
                .AsSelf()
                .As<IStartable>()
                .As<IDisposable>();

            builder.Register<InventoryStorageService>(Lifetime.Singleton);

            builder.Register<GameStateMachine>(Lifetime.Singleton)
                .AsSelf()
                .As<ITickable>();
            builder.Register<UIFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<UIRootController>();
        }
    }
}