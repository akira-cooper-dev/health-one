import { GeneratorConfig } from 'ng-openapi';

const config: GeneratorConfig = {
    input: "../backend/HealthOneWebServer/openapi.yaml",
    output: "src/app/api",
    options: {
        dateType: 'Date',
        enumStyle: 'enum',
    },
}

export default config;