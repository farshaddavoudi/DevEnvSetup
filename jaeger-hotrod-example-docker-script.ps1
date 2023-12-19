docker run --rm `
  -e JAEGER_AGENT_HOST=localhost `
  -e JAEGER_AGENT_PORT=6831 `
  -p 9080-9083:8080-8083 jaegertracing/example-hotrod:1.39.0

# Go to http://localhost:9080/ and play with the "HotROD - Rides On Demand" sample app to generate sample traces in Jaeger