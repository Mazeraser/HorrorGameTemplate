using UnityEngine;
using Unity.Cinemachine;
using VContainer;
using VContainer.Unity;
using System;
using Infrastructure.Interfaces;
using Infrastructure.Input;
using Infrastructure.Time;
using Infrastructure.Unity;
using Mechanics.Controllers;
using Mechanics.Movement;

namespace Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]private CharacterController controller;
        [SerializeField]private PlayerConfig config;
        [SerializeField]private CinemachineCamera playerCamera;
        [SerializeField]private Transform playerTransform;

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
            builder.RegisterEntryPoint<PlayerWalkController>();
            builder.RegisterEntryPoint<PlayerCameraController>();
        }
    }
}