# Avro Source Generation CSharp tests

This is a test project to demonstrate issues with generating Avro CSharp classes from Avro schema files that have
cross-file references to shared types.

## Setup

### Unit tests

This won't work out of the box. You'll need to package and publish a local version of the https://github.com/alfhv/avro
fork in order to test this.
Please follow the steps found in the [`AvroSourceGenerator.csproj`](AvroSourceGenerator/AvroSourceGenerator.csproj) file
to do so.

After creating your `2.0.0-local` version of `Apache.Avro`, run `dotnet test` to see the issue. The test will fail,
because the `PlanetEnum` has been generated twice.

### Source generator

If you'd like to see the same failure replicated via C# Source Generation (instead of unit tests), simply
comment back in either (or both) of the models found in the `_avroSchemasToGenerate` field in the
[`AvroGenerator`](AvroSourceGenerator/AvroGenerator.cs) class.

## Related links

* https://github.com/confluentinc/confluent-kafka-dotnet/issues/1127
* https://issues.apache.org/jira/browse/AVRO-3739
