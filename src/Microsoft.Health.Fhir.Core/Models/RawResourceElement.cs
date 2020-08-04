﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Text.Json;
using EnsureThat;
using Microsoft.Health.Fhir.Core.Features.Persistence;

namespace Microsoft.Health.Fhir.Core.Models
{
    public class RawResourceElement : IResourceElement
    {
        public RawResourceElement(ResourceWrapper wrapper)
        {
            EnsureArg.IsNotNull(wrapper, nameof(wrapper));
            EnsureArg.IsNotNull(wrapper.RawResource, nameof(wrapper.RawResource));

            JsonDocument = ResourceDeserializer.DeserializeToJsonDocument(wrapper);

            ResourceData = wrapper.RawResource.Data;
            Format = wrapper.RawResource.Format;
            Id = wrapper.ResourceId;
            VersionId = wrapper.Version;
            InstanceType = wrapper.ResourceTypeName;
            LastUpdated = wrapper.LastModified;
        }

        public string ResourceData { get; protected set; }

        public FhirResourceFormat Format { get; protected set; }

        public string Id { get; protected set; }

        public string VersionId { get; protected set; }

        public string InstanceType { get; protected set; }

        public DateTimeOffset? LastUpdated { get; protected set; }

        public JsonDocument JsonDocument { get; protected set; }
    }
}
