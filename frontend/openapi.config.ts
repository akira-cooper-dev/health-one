import { GeneratorConfig } from 'ng-openapi';

const config: GeneratorConfig = {
    input: "../backend/HealthOneWebServer/openapi.yaml",
    output: "src/app/api",
    options: {
        dateType: 'Date',
        enumStyle: 'enum',
        generateEnumBasedOnDescription: true,
        customizeMethodName(operationId) {
            const methodName = operationId.split('_').pop() ?? operationId;
            return methodName.charAt(0).toLowerCase() + methodName.slice(1);
        },
    },
}

export default config;